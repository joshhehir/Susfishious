using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePool : MonoBehaviour
{
    [SerializeField]
    private List<Thread> threads = new List<Thread>();
    [SerializeField]
    private List<Thread> available = new List<Thread>();
    [SerializeField]
    private List<Thread> priority = new List<Thread>();
    [SerializeField]
    private Thread currentThread;

    [SerializeField]
    private DialogueProgress progress;

    public Thread First => available[0];

    public void SaveThreadProgress()
    {
        progress.SaveProgress(threads);
    }

    public void LoadProgress()
    {
        progress.LoadProgress(threads);
    }

    

    public void AddThread(Thread t)
    {
        if (threads.Contains(t)) return;

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

    public void AddPriority(Thread t)
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

    public Thread GetStory()
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

        return currentThread;
    }
}
