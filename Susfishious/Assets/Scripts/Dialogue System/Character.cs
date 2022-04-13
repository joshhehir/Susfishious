using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

[System.Serializable]
public struct EventConnectors
{
    public Thread thread;
    public GameEvent gameEvent;
}

public class Character : MonoBehaviour, IInteract
{
    [SerializeField]
    private GameEvent enterDialogue;
    [SerializeField]
    private DialogueHolder currentDialogue;

    private DialoguePool dialoguePool;

    private void Start()
    {
        dialoguePool = GetComponent<DialoguePool>();
        foreach (Thread t in GetComponentsInChildren<Thread>())
        {
            dialoguePool.AddThread(t);
        }
        dialoguePool.LoadProgress();
        currentDialogue.thread = dialoguePool.First;
    }

    private void OnApplicationQuit()
    {
        dialoguePool.SaveThreadProgress();
    }

    private void OnDisable()
    {
        dialoguePool.SaveThreadProgress();
    }

    public void Interact()
    {
        currentDialogue.thread = dialoguePool.GetStory();
        enterDialogue.Raise();
    }

    public void AddToPriority(Thread t)
    {
        dialoguePool.AddPriority(t);
    }

    

    
}
