using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip dirtFootstepSound;
    public AudioClip woodFootstepSound;
    private AudioSource audioSource;

    private float timeBetweenSteps = 0.6f;
    private float nextStepTime = 0f;
    private string currentSurface = "";

    public float groundCheckDistance = 1.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.volume = 1f;
    }

    void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        string surfaceTag = GetCurrentSurface();

        if (isMoving)
        {
            if (Time.time >= nextStepTime)
            {
                if (surfaceTag != currentSurface)
                {
                    SetFootstepSound(surfaceTag);
                }

                if (!audioSource.isPlaying)
                {
                    PlayFootstepSound();
                }

                nextStepTime = Time.time + timeBetweenSteps;
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    string GetCurrentSurface()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
        {
            return hit.collider.tag;
        }
        return "";
    }

    void SetFootstepSound(string surfaceTag)
    {
        if (surfaceTag == "Dirt")
        {
            if (currentSurface != "Dirt")
            {
                audioSource.clip = dirtFootstepSound;
                currentSurface = "Dirt";
            }
        }
        else if (surfaceTag == "Wood")
        {
            if (currentSurface != "Wood")
            {
                audioSource.clip = woodFootstepSound;
                currentSurface = "Wood";
            }
        }
    }

    void PlayFootstepSound()
    {
        audioSource.Play();
    }
}
