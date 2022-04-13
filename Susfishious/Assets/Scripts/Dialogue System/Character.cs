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

    [SerializeField]
    private List<Thread> threads = new List<Thread>();
    [SerializeField]
    private List<Thread> available = new List<Thread>();
    [SerializeField]
    private List<Thread> priority = new List<Thread>();
    [SerializeField]
    private Thread currentThread;

    private void Start()
    {
        foreach (Thread t in GetComponentsInChildren<Thread>())
        {
            threads.Add(t);
            if (t.GetThreadTags()[0] == "FIRST")
            {
                priority.Add(t);
                currentThread = t;
            }
            if (!t.locked)
            {
                available.Add(t);
            }
        }
        currentDialogue.thread = available[0];
    }

    public void Interact()
    {
        GetStory();
        //PlayerController.instance.StartDialogue();
    }

    public void AddToPriority(Thread t)
    {
        if (priority.Contains(t)) return;
        priority.Add(t);
    }

    public Thread GetThreadByName(string name)
    {
        foreach (Thread t in threads)
        {
            if (t.name == name)
            {
                return t;
            }
        }
        return null;
    }

    public void GetStory()
    {
        available.Remove(currentThread);
        if (!currentThread.Complete)
        {
            available.Insert(available.Count, currentThread);
        }
        
        if (priority.Count > 0)
        {
            currentThread = priority[0];
            priority.RemoveAt(0);
        }
        else
        {
            currentThread = available[0];
            foreach (Thread t in available)
            {
                if (t.priority > currentThread.priority)
                {
                    currentThread = t;
                }
            }
            
        }
        
        currentDialogue.thread = currentThread;
        enterDialogue.Raise();
    }
}
