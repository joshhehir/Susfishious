using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private CharacterController controller;

    [SerializeField]
    private float speed = 7;
    [SerializeField]
    private float fallSpeed;

    private PlayerInput input;
    private InputAction move;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    Vector3 velocity;

    [SerializeField]
    bool isGrounded;


    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;

            input = GetComponent<PlayerInput>();
            move = input.actions["Move"];

            controller = GetComponent<CharacterController>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Vector2 input = move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0, input.y);
        velocity.y = isGrounded ? 0 : velocity.y + fallSpeed * Time.deltaTime;

        controller.Move(direction * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}
