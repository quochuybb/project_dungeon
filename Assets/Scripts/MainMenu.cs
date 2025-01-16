using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // playgame button
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    // quit game button
    public void QuitGame()
    {
        Application.Quit();
    }
}
