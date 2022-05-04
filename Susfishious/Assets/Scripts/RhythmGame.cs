using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RhythmGame : MonoBehaviour, IInteract
{
    public GameObject rhythmGame;

    public bool isActive;

    private InputAction rhythmAction;

    // Start is called before the first frame update
    void Start()
    {
        rhythmAction = ThirdPersonController.instance.GetComponent<PlayerInput>().actions["Interact"];
        rhythmGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(rhythmAction.triggered)
        {
            //if(isActive)
            //{
                StartRhythmGame();
            //}
            //else
            //{
            //
            //    EndRhythmGame();
            //}
        }
    }

    public void Interact()
    {
        StartRhythmGame();
    }

    public void StartRhythmGame()
    {
        rhythmGame.SetActive(true);
        //Time.timeScale = 0f;
        isActive = true;
    }

    public void EndRhythmGame()
    {
        rhythmGame.SetActive(false);
        //Time.timeScale = 1f;
        isActive = false;
    }
}
