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
    public delegate void threadPass(Thread t);
    public static event threadPass startDialogue;

    private DialoguePool dialoguePool;

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
        startDialogue.Invoke(dialoguePool.GetStory());
    }

    public void AddToPriority(Thread t)
    {
        dialoguePool.AddPriority(t);
    }

    

    
}
