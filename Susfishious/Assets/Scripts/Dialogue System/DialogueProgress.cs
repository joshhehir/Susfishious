using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.Linq;

[CreateAssetMenu]
public class DialogueProgress : ScriptableObject
{
    [SerializeField]
    private List<string> threadStates;

    public void LoadProgress(List<Thread> threads)
    {
        for (int i = 0; i < threadStates.Count; i++)
        {
            threads[i].LoadProgress(threadStates[i]);
        }
    }

    public void SaveProgress(List<Thread> threads)
    {
        threadStates.Clear();
        foreach (Thread t in threads)
        {
            threadStates.Add(t.GetState());
        }
    }
}
