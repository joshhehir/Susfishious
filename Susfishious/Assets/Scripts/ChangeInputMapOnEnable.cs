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
        inputs = ThirdPersonController.instance.GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        if (inputs == null)
        {
            inputs = ThirdPersonController.instance.GetComponent<PlayerInput>();
        }
        inputs.SwitchCurrentActionMap(InputMapOnEnable);
    }
}
