using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public Sprite sprite;
    public string name;
    public string description;
    public string itemMutation;

    public bool caught;
}
