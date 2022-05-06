using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RhythmGame : MonoBehaviour, IInteract
{
    public GameObject rhythmGame;

    public bool isActive = false;

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
        
    }

    public void Interact()
    {
        if(isActive == false)
        {
            StartRhythmGame();
        }
        else
        {
            EndRhythmGame();
        }
    }

    public void StartRhythmGame()
    {
        rhythmGame.SetActive(true);
        isActive = true; 
    }

    public void EndRhythmGame()
    {
        rhythmGame.SetActive(false);
        isActive = false;
    }
}
