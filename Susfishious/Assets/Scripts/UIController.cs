using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    private PlayerInput inputs;

    [SerializeField]
    private GameObject dialogueUI;
    [SerializeField]
    private GameObject journalUI;
    [SerializeField]
    private GameObject rhythmGameUI;

    private InputAction openJournal;

    // Start is called before the first frame update
    void Start()
    {
        Character.startDialogue += StartDialogue;
        inputs = ThirdPersonController.instance.GetComponent<PlayerInput>();
        openJournal = inputs.actions["OpenJournal"];
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
            if (openJournal.triggered)
            {
                journalUI.SetActive(true);
            }
        }
        
    }

    public bool UIActive()
    {
        if (dialogueUI.activeInHierarchy == true) return true;
        if (journalUI.activeInHierarchy == true) return true;
        if (rhythmGameUI.activeInHierarchy == true) return true;

        return false;
    }
    
    public void StartDialogue(Character c)
    {
        dialogueUI.SetActive(true);
        dialogueUI.GetComponent<DialogueController>().Resume(c);
    }
}
