using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction jump;

    [SerializeField]
    public float speed;
    public float jumpForce = 5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private bool isGrounded;


    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        jump = playerInput.actions.FindAction("Jump");
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, (int)WhatIsGround);

        Debug.Log(isGrounded);

        MovePlayer();
    }
    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime * speed;
    }
    private void OnEnable()
    {
        jump.Enable();
    }

    private void FixedUpdate()
    {
        if (jump.IsPressed() && isGrounded == true)
        {
            if (gameObject.transform.position.y < 3.4f)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
