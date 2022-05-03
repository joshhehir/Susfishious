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
    public delegate void characterPass(Character c);
    public static event characterPass startDialogue;

    public DialoguePool dialoguePool;

    public Thread CurrentThread => dialoguePool.currentThread;
    private void Start()
    {
        dialoguePool = GetComponent<DialoguePool>();
        foreach (Thread t in GetComponentsInChildren<Thread>())
        {
            dialoguePool.AddThread(t);
        }
        dialoguePool.LoadProgress();
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
        dialoguePool.GetStory();
        startDialogue.Invoke(this);
    }

    public void AddToPriority(Thread t)
    {
        dialoguePool.AddPriority(t);
    }

    public void SaveConversation(Transform t)
    {
        dialoguePool.SaveConversation(t);
    }

    public List<DialogueEntry> LoadConversation()
    {
        return dialoguePool.DialogueEntries;
    }
}
