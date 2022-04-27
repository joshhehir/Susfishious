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
    private Image portrait;
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
        inputs = PlayerController.instance.GetComponent<PlayerInput>();
        continueAction = inputs.actions["Next"];
    }

    public void Resume(Character c)
    {
        if (c != null) currentCharacter = c;

        foreach (Message m in container.GetComponentsInChildren<Message>())
        {
            Destroy(m.gameObject);
        }
        var dialogueEntries = currentCharacter.LoadConversation();

        foreach (DialogueEntry d in dialogueEntries)
        {
            if (d.isResponse)
            {
                CreateResponse(d.text);
            }
            else
            {
                CreateMessage(d.text);
            }
        }

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
            CreateResponse(c.text);
        }
    }

    public void ChoiceMadeByButton(GameObject g)
    {
        foreach (GameObject gameObject in responses)
        {
            if (gameObject.GetComponentInChildren<DialogueChoice>().gameObject == g)
            {
                MakeChoice(responses.IndexOf(gameObject));
            }
        }
    }

    public void DestoryChoices(int index)
    {
        Debug.Log(index + " : " + responses.Count);
        for (int i = 0; i < responses.Count; i++)
        {
            if (i != index) Destroy(responses[i].gameObject);
        }
    }

    private void Continue()
    {
        Thread.story.Continue();
        CreateMessage(Thread.story.currentText);
    }

    private void CreateMessage(string text)
    {
        lastMessage = Instantiate(messagePrefab, container.transform).GetComponent<Message>();
        lastMessage.SetText(text);
    }

    private void CreateResponse(string text)
    {
        GameObject button = Instantiate(buttonPrefab, container.transform);
        button.GetComponent<Message>().SetText(text);
        responses.Add(button.gameObject);
        button.transform.localScale = new Vector3(1, 1, 1);
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
        currentCharacter.SaveConversation(transform);
    }
}
