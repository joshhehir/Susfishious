using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.Linq;

public struct DialogueEntry
{
    public string text;
    public bool isResponse;
}


[CreateAssetMenu]
public class DialogueProgress : ScriptableObject
{
    [SerializeField]
    private List<string> threadStates;
    [SerializeField]
    private List<DialogueEntry> conversationLog;

    public void LoadProgress(List<Thread> threads)
    {
        for (int i = 0; i < threadStates.Count; i++)
        {
            threads[i].LoadProgress(threadStates[i]);
        }
    }

    public void SaveProgress(List<Thread> threads, Transform content)
    {
        threadStates.Clear();
        foreach (Thread t in threads)
        {
            threadStates.Add(t.GetState());
        }
        conversationLog.Clear();
        foreach (Message m in content.GetComponentsInChildren<Message>())
        {
            conversationLog.Add(new DialogueEntry() { text = m.CurrentText, isResponse = m.name == "Response" });
        }
    }
}
