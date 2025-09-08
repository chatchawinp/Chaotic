using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void start_game ()
    {
        SceneManager.LoadScene(1);
    }

    public void main_menu ()
    {
        SceneManager.LoadScene(0);
    }

    public void exit_game ()
    {
        Application.Quit();
    }
}
