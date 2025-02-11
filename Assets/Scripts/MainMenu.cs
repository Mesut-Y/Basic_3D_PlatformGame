using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
            SceneManager.LoadScene(0);
    }

    public void PlayApp()
    {
        SceneManager.LoadScene(1); //"Level01" ismi de �al�r�labilir.
    }

    public void AppQuit()
    {
        Application.Quit();
        Debug.Log("��k�� Yap�ld�.");
    }

    public void AppMenu()
    {
        SceneManager.LoadScene(0);
    }
}
