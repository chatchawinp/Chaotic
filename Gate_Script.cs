using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate_Script : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered gate. Score: " + Text_Display.score);

            if (Text_Display.score >= 5)
            {
                Debug.Log("Loading Scene 2...");
                SceneManager.LoadScene(2);
            }
            else
            {
                Debug.Log("Score is too low to proceed.");
            }
        }
    }
}
