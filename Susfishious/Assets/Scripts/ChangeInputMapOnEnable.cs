using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeInputMapOnEnable : MonoBehaviour
{
    private PlayerInput inputs;

    [SerializeField]
    private string InputMapOnEnable;

    private void Start()
    {
        inputs = GameObject.Find("Player").GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        if (inputs == null)
        {
            inputs = GameObject.Find("Player").GetComponent<PlayerInput>();
        }
        inputs.SwitchCurrentActionMap(InputMapOnEnable);
    }
}
