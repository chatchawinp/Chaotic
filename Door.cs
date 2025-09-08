using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    bool trig, open; // trig-การตรวจจับการเข้าออกใน trigger (ผู้เล่นต้องมี tag "Player") open-สถานะเปิดปิดประตู
    public float smooth = 2.0f; // ความเร็วในการหมุนประตู
    public float DoorOpenAngle = 90.0f; // มุมหมุนประตู
    private Vector3 defaulRot;
    private Vector3 openRot;
    public Text txt; // ข้อความใน UI
    public AudioClip doorOpenSound; // เสียงเปิดประตู
    public AudioClip doorCloseSound; // เสียงปิดประตู
    private AudioSource audioSource; // อ้างอิงถึง AudioSource

    void Start()
    {
        defaulRot = transform.eulerAngles;
        openRot = new Vector3(defaulRot.x, defaulRot.y + DoorOpenAngle, defaulRot.z);
        audioSource = GetComponent<AudioSource>(); // รับ AudioSource จาก GameObject
    }

    void Update()
    {
        if (open) // ถ้าประตูเปิด
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        else // ถ้าประตูปิด
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaulRot, Time.deltaTime * smooth);
        }

        if (Input.GetKeyDown(KeyCode.E) && trig)
        {
            open = !open; // สลับสถานะเปิด/ปิดประตู
            PlayDoorSound(); // เล่นเสียงเมื่อเปิด/ปิดประตู
        }

        if (trig)
        {
            if (open)
            {
                txt.text = "Close E";
            }
            else
            {
                txt.text = "Open E";
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            if (!open)
            {
                txt.text = "Close E ";
            }
            else
            {
                txt.text = "Open E";
            }
            trig = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            txt.text = " ";
            trig = false;
        }
    }

    // ฟังก์ชันสำหรับเล่นเสียงเปิดหรือปิดประตู
    void PlayDoorSound()
    {
        if (open && doorOpenSound != null) // ถ้าประตูเปิด ให้เล่นเสียงเปิด
        {
            audioSource.PlayOneShot(doorOpenSound);
        }
        else if (!open && doorCloseSound != null) // ถ้าประตูปิด ให้เล่นเสียงปิด
        {
            audioSource.PlayOneShot(doorCloseSound);
        }
    }
}
