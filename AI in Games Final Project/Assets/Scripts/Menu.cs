using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        Cursor.visible = false ;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
