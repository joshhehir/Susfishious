using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject journal;
    public bool isPaused;

    private InputAction pauseAction;

    public string MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseAction = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["Pause"];
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseAction.triggered)
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        SetPauseMenuActive(true);
    }

    private void SetPauseMenuActive(bool active)
    {
        journal.SetActive(active);
        //this will hopefully be more robust later
        journal.GetComponent<JournalUI>().LoadTab(3);
        Time.timeScale = active ? 0f : 1f;
        isPaused = active;
    }

    public void ResumeGame()
    {
        SetPauseMenuActive(false);
        
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
