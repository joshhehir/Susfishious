using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    private PlayerInput inputs;
    private InputAction interact;

    [SerializeField]
    private GameObject dialogueUI;

    private bool changeState;

    // Start is called before the first frame update
    void Start()
    {
        inputs = GameObject.Find("Player").GetComponent<PlayerInput>();
        interact = inputs.actions["Interact"];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIActive())
        {
            if (inputs.currentActionMap.name != "Character")
            {
                Debug.Log("UI Disabled, actionmap set to character");
                inputs.SwitchCurrentActionMap("Character");
            }
            if (interact.triggered)
            {
                ActivateDialogueUI();
            }
        }
    }

    public bool UIActive()
    {
        if (dialogueUI.activeInHierarchy == true) return true;
        return false;
    }

    public void ActivateDialogueUI()
    {
        dialogueUI.SetActive(true);
    }
}
