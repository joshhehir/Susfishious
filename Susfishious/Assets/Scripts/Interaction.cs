using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private SpriteRenderer render;
    [SerializeField]
    private GameEvent modulePickup;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        ChangeVisibility(false);
    }

    public void ChangeVisibility(bool value)
    {
        render.enabled = value;
    }

    public void Interact()
    {
        transform.parent.GetComponent<IInteract>().Interact();
    }
}
