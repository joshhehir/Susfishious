using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.Linq;

[System.Serializable]
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
    private List<DialogueEntry> conversationLog = new List<DialogueEntry>();

    public List<DialogueEntry> ConversationLog => conversationLog;

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

    public void SaveConversation(Transform content)
    {
        conversationLog.Clear();
        foreach (Message m in content.GetComponentsInChildren<Message>())
        {
            Debug.Log(m.name);
            conversationLog.Add(new DialogueEntry() { text = m.CurrentText, isResponse = m.name == "Response Option(Clone)" });
        }
    }
}
