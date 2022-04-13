using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IListenGameEvent
{
    public void OnEventRaised(GameEvent gameEvent);
    public void OnEventRaised(GameEvent gameEvent, GameObject gameObject);
}
