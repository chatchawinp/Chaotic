using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound;  // เสียงที่ต้องการเล่นเมื่อกดปุ่ม
    private AudioSource audioSource;    // อ้างอิงถึง AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // รับ AudioSource จาก GameObject
    }

    public void OnButtonClick()
    {
        StartCoroutine(PlayButtonClickSoundAndExecute());  // เริ่ม Coroutine
    }

    // Coroutine ที่จะเล่นเสียงก่อนที่จะทำการเปิดเมนูหรือทำงานอื่น
    private IEnumerator PlayButtonClickSoundAndExecute()
    {
        // เล่นเสียงเมื่อกดปุ่ม
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);  // เล่นเสียง
        }

        // รอให้เสียงเล่นเสร็จ (เวลาของเสียง)
        yield return new WaitForSeconds(buttonClickSound.length);

        // ทำงานที่ต้องการหลังจากเสียงเล่นเสร็จ
        ExecuteButtonAction();
    }

    // ฟังก์ชันที่ทำงานจริง ๆ หลังจากเสียงเสร็จ
    private void ExecuteButtonAction()
    {
        // ตัวอย่างเช่น เปิดเมนูหรือการทำงานอื่น ๆ
        Debug.Log("Button clicked and sound played!");
        // ตัวอย่าง: เรียกฟังก์ชันที่เปิดเมนู
        // SceneManager.LoadScene("MainMenu");
    }
}
