using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    public Thread currentThread;

    private string CurrentText => currentThread.story.currentText;
    private Thread Thread => currentThread;
    [SerializeField]
    private GameObject messagePrefab;

    [SerializeField]
    private TextMeshProUGUI dialogue;
    [SerializeField]
    private Image portrait;
    [SerializeField]
    private AudioSource soundEffects;

    private PlayerInput inputs;
    private InputAction continueAction;

    [SerializeField]
    private Transform buttonContainer;

    [SerializeField]
    private List<GameObject> buttons;
    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private Message lastMessage;

    private void Start()
    {
        inputs = PlayerController.instance.GetComponent<PlayerInput>();
        continueAction = inputs.actions["Next"];
    }

    private void OnEnable()
    {
        if (Thread.story.canContinue)
        {
            Continue();
        }

        if (Thread.story.currentChoices.Count > 0)
        {
            GenerateChoices();
        }
    }
    private void Update()
    {
        if (Thread != null)
        {
            
            if (Thread.story.canContinue)
            {
                if (continueAction.triggered)
                {
                    if (!lastMessage.FinishedRevealing)
                    {
                        lastMessage.RevealAll();
                    }
                    else
                    {
                        Continue();
                        //Thread.CheckTags();
                        if (Thread.story.currentChoices.Count > 0)
                        {
                            GenerateChoices();
                        }
                    }

                }
            }
            else
            {
                if (Thread.story.currentChoices.Count <= 0)
                {
                    if (continueAction.triggered)
                    {
                        if (!lastMessage.FinishedRevealing)
                        {
                            lastMessage.RevealAll();
                        }
                        else
                        {
                            //end dialogue.
                            Thread.CheckTags();

                            gameObject.SetActive(false);

                        }
                    }
                }

            }
        }
    }

    public void GenerateChoices()
    {
        Debug.Log("generating choices");
        List<Choice> choices = Thread.story.currentChoices;
        Debug.Log(choices.Count);
        
        foreach (Choice c in choices)
        {
            GameObject button = Instantiate(buttonPrefab);
            buttons.Add(button);
            button.transform.SetParent(buttonContainer);
            button.transform.localScale = new Vector3(1, 1, 1);
            button.GetComponentInChildren<TMP_Text>().text = c.text;
        }
    }

    public void ChoiceMadeByButton(GameObject g)
    {
        foreach (GameObject gameObject in buttons)
        {
            if (gameObject == g)
            {
                MakeChoice(buttons.IndexOf(gameObject));
            }
        }
    }

    public void DestoryChoices()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i]);
        }
    }

    private void Continue()
    {
        Thread.story.Continue();
        lastMessage = Instantiate(messagePrefab).GetComponent<Message>();
        lastMessage.SetText(Thread.story.currentText);
    }

    public void MakeChoice(int index)
    {
        Thread.UpdatePath(Thread.story.currentChoices[index].pathStringOnChoice);
        Thread.story.ChooseChoiceIndex(index);
        Continue();
        //Thread.CheckTags();
        DestoryChoices();

    }
}
