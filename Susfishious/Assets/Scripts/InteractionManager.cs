using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private List<Interaction> interactions;
    private Interaction selectedInteraction;

    private InputAction interactAction;

    // Start is called before the first frame update
    void Start()
    {
        interactAction = PlayerController.instance.GetComponent<PlayerInput>().actions["Interact"];
    }

    // Update is called once per frame
    void Update()
    {
        interactions.RemoveAll(delegate (Interaction i) { return i == null; });
        if (interactAction.triggered)
        {
            selectedInteraction?.Interact();
        }

        if (interactions.Count == 1)
        {
            selectedInteraction = interactions[0];
        }
        else
        {
            foreach (Interaction i in interactions)
            {
                if (i != null)
                {
                    i.ChangeVisibility(false);
                    if (selectedInteraction == null)
                    {
                        selectedInteraction = i;
                    }
                    else if (Vector2.Distance(transform.position, i.transform.position) < Vector2.Distance(transform.position, selectedInteraction.transform.position))
                    {
                        selectedInteraction = i;
                    }
                }
            }
        }

        if (selectedInteraction != null)
        {
            selectedInteraction.ChangeVisibility(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interaction"))
        {
            if (interactions.Count < 1)
            {
                //SoundManager.PlaySound(interactionPromptSound, 0.2f);
            }
            interactions.Add(other.GetComponent<Interaction>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interaction"))
        {
            Interaction i = other.GetComponent<Interaction>();
            i.ChangeVisibility(false);

            interactions.Remove(other.GetComponent<Interaction>());
            if (selectedInteraction == i)
            {
                selectedInteraction = null;
            }
        }
    }
}
