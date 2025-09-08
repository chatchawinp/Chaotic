using UnityEngine;
using UnityEngine.UI; // สำหรับใช้ Text UI
using System.Collections; // เพิ่มการใช้ Coroutine

public class SkullScript : MonoBehaviour
{
    private bool isPlayerInRange = false; // เช็คว่าผู้เล่นอยู่ในระยะหรือไม่
    public Text txt; // ตัวแปร Text ที่จะใช้แสดงข้อความ
    public AudioClip collectSound; // เสียงเมื่อเก็บไม้กางเขน
    private AudioSource audioSource; // อ้างอิงถึง AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // รับ AudioSource จาก GameObject
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true; // ผู้เล่นเข้ามาในระยะ
            txt.text = "Press E to Collect"; // แสดงข้อความ "Press E to Collect"
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false; // ผู้เล่นออกจากระยะ
            txt.text = ""; // ลบข้อความเมื่อผู้เล่นออกจากระยะ
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Text_Display.score += 1; // เพิ่มคะแนนเมื่อเก็บไม้กางเขน
            txt.text = ""; // ลบข้อความก่อน
            audioSource.PlayOneShot(collectSound); // เล่นเสียงเก็บไม้กางเขน
            StartCoroutine(DestroyAfterSound()); // เรียกใช้ Coroutine เพื่อทำให้ไม้กางเขนหายไปหลังจากเสียงเล่นจบ
        }
    }

    // Coroutine สำหรับทำให้ไม้กางเขนหายไปหลังจากเสียงเล่นจบ
    IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(collectSound.length); // รอจนกว่าเสียงจะเล่นเสร็จ
        Destroy(gameObject); // ทำไม้กางเขนหายไป
    }
}
