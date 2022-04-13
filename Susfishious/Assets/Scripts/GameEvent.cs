using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<IListenGameEvent> listeners = new List<IListenGameEvent>();

    public void Raise()
    {
        for (int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(this);
        }
    }

    public void Raise(GameObject gameobject)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(this, gameobject);
        }
    }

    public void RegisterListener(IListenGameEvent listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(IListenGameEvent listener)
    {
        listeners.Add(listener);
    }
}
