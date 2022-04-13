using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChoice : MonoBehaviour
{
    [SerializeField]
    private GameEvent choiceMade;
    public void OnButtonClick()
    {
        Debug.Log("choice made");
        choiceMade.Raise(gameObject);
    }
}
