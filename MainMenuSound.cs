using UnityEngine;

public class MainMenuSound : MonoBehaviour
{
    public AudioClip menuSound;   // เสียงที่ต้องการเล่นเมื่อ Main Menu เปิด
    private AudioSource audioSource;  // อ้างอิงถึง AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // รับ AudioSource จาก GameObject
        PlayMenuSound(); // เล่นเสียงเมื่อเปิดเมนู
    }

    void PlayMenuSound()
    {
        if (menuSound != null) // ถ้ามีเสียงให้เล่น
        {
            audioSource.PlayOneShot(menuSound); // เล่นเสียงที่กำหนด
        }
    }
}
