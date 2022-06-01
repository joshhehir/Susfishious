using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    private PlayerInput input;
    private CharacterController character;
    private Animator anim;
    private SpriteRenderer render;
    private InputAction move;

    [SerializeField]
    private float movementForce;
    [SerializeField]
    private Vector3 forceDirection;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        render = GetComponentInChildren<SpriteRenderer>();

        move = input.actions["Move"];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.distance > 0)
            {
                transform.position -= new Vector3(0,hit.distance,0);
            }
        }
        forceDirection = new Vector3(-move.ReadValue<Vector2>().y * movementForce, 0, move.ReadValue<Vector2>().x * movementForce);
        character.Move(forceDirection);

        anim.SetBool("Walking", forceDirection.z > 0.1 || forceDirection.z < -0.1);
        render.flipX = forceDirection.z < -0.1;
        anim.SetBool("Down", forceDirection.x > 0.1);
    }
}
