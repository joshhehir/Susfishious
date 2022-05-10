using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void GameSettings()
    {
        Debug.Log("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
