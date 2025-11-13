using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaseCharacter : MonoBehaviour
{
    public Transform player;
    public Animator animator;

    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float chaseRange = 10f;
    public float deathRange = .75f;

    private Vector3 spawnPoint;
    private bool isChasing = false;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        ChasePlayer(distance);
        PlayerDeath(distance);
    }

    private void PlayerDeath(float distance)
    {
        if (distance < deathRange)
        {
            SceneManager.LoadScene("Jumpscare");
        }
    }

    private void ChasePlayer(float distance)
    {
        if (distance < chaseRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * moveSpeed * Time.deltaTime;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
