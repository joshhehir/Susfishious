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
    public Character currentCharacter;

    private string CurrentText => currentCharacter.CurrentThread.story.currentText;
    private Thread Thread => currentCharacter.CurrentThread;
    [SerializeField]
    private GameObject messagePrefab;
    [SerializeField]
    private GameObject container;

    [SerializeField]
    private TextMeshProUGUI dialogue;
    [SerializeField]
    private Image playerPortrait;
    [SerializeField]
    private Image characterPortrait;
    [SerializeField]
    private AudioSource soundEffects;

    private PlayerInput inputs;
    private InputAction continueAction;

    [SerializeField]
    private Transform buttonContainer;

    [SerializeField]
    private List<GameObject> responses;
    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private Message lastMessage;

    private void Start()
    {
        inputs = ThirdPersonController.instance.GetComponent<PlayerInput>();
        continueAction = inputs.actions["Next"];
    }

    public void Resume(Character c)
    {

        if (currentCharacter != c) currentCharacter = c;

        foreach (Message m in container.GetComponentsInChildren<Message>())
        {
            Destroy(m.gameObject);
        }
        var dialogueEntries = currentCharacter.LoadConversation();

        foreach (DialogueEntry d in dialogueEntries)
        {
            if (d.isResponse)
            {
                CreateResponse(d.text, true);
            }
            else
            {
                CreateMessage(d.text, true);
            }
        }

        if (Thread.story.currentChoices.Count > 0)
        {
            Debug.Log("Generating Choices");
            GenerateChoices();
        }
        else
        {
            Thread.GetCurrentStory();
            Continue();
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
                        
                    }

                }
            }
            else
            {
                if (!lastMessage.FinishedRevealing)
                {
                    if (continueAction.triggered) lastMessage.RevealAll();
                }
                else if (responses.Count == 0)
                {
                    if (continueAction.triggered && Thread.story.currentChoices.Count > 0)
                    {
                        GenerateChoices();
                    }
                    else if (continueAction.triggered)
                    {
                        //end dialogue.
                        Thread.CheckTags();

                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public void GenerateChoices()
    {
        //Destory all choices
        DestoryChoices(-1);
        responses.Clear();
        List<Choice> choices = Thread.story.currentChoices;
        Debug.Log(choices.Count);
        
        foreach (Choice c in choices)
        {
            CreateResponse(c.text, false);
        }
    }

    public void ChoiceMadeByButton(GameObject g)
    {
        GameObject chosen = null;
        foreach (GameObject gameObject in responses)
        {
            if (gameObject.GetComponentInChildren<DialogueChoice>().gameObject == g)
            {
                chosen = gameObject;
            }
        }
        MakeChoice(responses.IndexOf(chosen));
    }

    public void DestoryChoices(int index)
    {
        for (int i = 0; i < responses.Count; i++)
        {
            if (i != index) Destroy(responses[i]);
            
        }
        responses.Clear();
    }

    private void Continue()
    {
        Thread.story.Continue();
        CreateMessage(Thread.story.currentText, false);
    }

    private void CreateMessage(string text, bool skipTyping)
    {
        lastMessage = Instantiate(messagePrefab, container.transform).GetComponent<Message>();
        lastMessage.SetText(text, skipTyping);
    }

    private void CreateResponse(string text, bool history)
    {
        GameObject button = Instantiate(buttonPrefab, container.transform);
        button.GetComponent<Message>().SetText(text, true);
        if (!history) responses.Add(button.gameObject);
        //button.transform.localScale = new Vector3(1, 1, 1);
        button.GetComponentInChildren<TMP_Text>().text = text;
    }

    public void MakeChoice(int index)
    {
        Thread.UpdatePath(Thread.story.currentChoices[index].pathStringOnChoice);
        Thread.story.ChooseChoiceIndex(index);
        Continue();
        //Thread.CheckTags();
        DestoryChoices(index);
    }

    private void OnDisable()
    {
        DestoryChoices(-1);
        currentCharacter.SaveConversation(transform);
    }
}
