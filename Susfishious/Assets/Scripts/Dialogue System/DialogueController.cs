using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Ink.Runtime;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private DialogueHolder currentDialogue;

    private Thread thread => currentDialogue.thread;

    private PlayerInput inputs;
    private InputAction continueAction;

    [SerializeField]
    private GameObject dialogueUI;
    [SerializeField]
    private GameObject playerPortrait;
    [SerializeField]
    private GameObject characterPortrait;
    [SerializeField]
    private TMP_Text dialogue;
    [SerializeField]
    private TMP_Text response;

    // Start is called before the first frame update
    void Start()
    {
        inputs = PlayerController.instance.GetComponent<PlayerInput>();
        continueAction = inputs.actions["Next"];


    }



    // Update is called once per frame
    void Update()
    {
        if (thread != null)
        {
            dialogueUI.SetActive(inputs.currentActionMap.name == "Dialogue");
            response.text = "";
            dialogue.text = thread.story.currentText;
            if (thread.story.canContinue)
            {
                if (continueAction.triggered)
                {
                    
                    thread.story.Continue();
                    thread.CheckTags();
                }
            }
            else
            {
                if (thread.story.currentChoices.Count <= 0)
                {
                    if (continueAction.triggered)
                    {
                        //end dialogue.
                        inputs.SwitchCurrentActionMap("Character");
                    }
                }
                int index = 0;
                foreach (Choice choice in thread.story.currentChoices)
                {
                    index++;
                    response.text += index + ". " + choice.text + "\n";
                }
            }


            //playerPortrait.SetActive(!thread.story.canContinue);
            //characterPortrait.SetActive(thread.story.canContinue);
        }
        
    }

    public void MakeChoice(int index)
    {
        thread.story.ChooseChoiceIndex(index);
        thread.story.Continue();
    }

    public void SetThread(Thread t)
    {
        currentDialogue.thread = t;
        if (thread.story.canContinue)
        {
            thread.story.Continue();
        }
        
    }
}
