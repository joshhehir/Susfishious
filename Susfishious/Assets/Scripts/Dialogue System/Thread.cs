using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public enum ThreadPriority
{
    LOW,
    STANDARD,
    HIGH,
    ESSENTIAL 
}

[System.Serializable]
public class Thread : MonoBehaviour, IListenGameEvent
{

    [SerializeField]
    private TextAsset asset;
    public Story story;
    public ThreadPriority priority;
    private string currentKnot = "main";
    private string currentStitch;

    public bool locked;

    private int progress = 0;

    [SerializeField]
    private List<GameEvent> listenTo = new List<GameEvent>();
    [SerializeField]
    private List<GameEvent> invoke = new List<GameEvent>();

    private void Awake()
    {
        InitializeStory();
    }

    public void LoadProgress(string s)
    {
        story.state.LoadJson(s);
    }

    public void UpdatePath(string s)
    {
        currentKnot = s.Split('.')[0];
        currentStitch = s.Contains('.') ? currentStitch = s.Split('.')[1] : "";
    }

    public string GetState()
    {
        return story.state.ToJson();
    }

    public void OnEventRaised(GameEvent gameEvent)
    {
        if (gameEvent == listenTo[progress])
        {
            Progress();
        }
    }
    public void OnEventRaised(GameEvent gameEvent, GameObject gameObject)
    {
        OnEventRaised(gameEvent);
    }

    private void InitializeStory()
    {
        LoadNewInk(asset);
        if (story.globalTags != null)
        {
            foreach (string s in story.globalTags)
            {
                if (s.Contains("LOCKED:"))
                {
                    locked = true;
                }

            }
        }
        priority = (ThreadPriority)(int)story.variablesState["priority"];
        story.ObserveVariable("priority", (string str, object newValue) => { UpdatePriority((int)newValue); });
        
    }

    private void OnEnable()
    {
        foreach (GameEvent g in listenTo)
        {
            g.RegisterListener(this);
        }
    }

    private void OnDisable()
    {
        foreach (GameEvent g in listenTo)
        {
            g.UnRegisterListener(this);
        }
    }

    private void UpdatePriority(int newValue)
    {
        priority = (ThreadPriority)newValue;
    }

    private void Invoke(string name)
    {
        foreach (GameEvent g in invoke)
        {
            if (g.name == name)
            {
                Debug.Log("Invoking event " + name);
                g.Raise();
            }
        }
    }

    private void LoadNewInk(TextAsset newFile)
    {
        story = new Story(newFile.text);
    }

    public void UnlockThread()
    {
        if (!Complete)
        {
            locked = false;
            GetComponentInParent<Character>().AddToPriority(this);
        }
    }

    public void CheckTags()
    {
        foreach (string t in story.currentTags)
        {
            if (t.Contains("EVENT"))
            {
                string s = t.Replace("EVENT:", "").Trim();
                Invoke(s);
            }
        }
    }

    public void Progress()
    {
        if (!story.canContinue)
        {
            if (story.TagsForContentAtPath(currentKnot).Count > 0)
            {
                currentKnot = story.TagsForContentAtPath(currentKnot)[0].Split(':')[1].Trim();
                progress++;
            }
        }
    }

    public bool Complete
    {
        get
        {
            foreach (string s in story.currentTags)
            {
                Debug.Log(s);
            }
            return !story.canContinue && story.currentTags.Count == 0;
        }
        
    }

    public string Name
    {
        get
        {
            return asset.name;
        }
    }

    public bool Waiting
    {
        get
        {
            return !story.canContinue && story.currentTags.Count > 0;
        }
    }

    public List<string> GetThreadTags()
    {
        return story.globalTags != null ? story.globalTags : new List<string>() { "Empty" };
    }

    private void ChangePath()
    {
        string pathString = currentKnot;
        if (currentStitch != "")
        {
            pathString += "." + currentStitch;
        }
        story.ChoosePathString(pathString);
    }

    public Story GetCurrentStory()
    {
        if (!story.canContinue)
        {
            foreach(string s in story.currentTags)
            {
                if (s.Contains("RESUME"))
                {

                    currentKnot = s.Replace("RESUME:", "").Trim();
                    ChangePath();
                }
            }
        }
        return story;
    }
}
