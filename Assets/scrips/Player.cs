using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("References")]
    public Transform groundCheck;

    private Rigidbody rb;
    private bool isGrounded;
    private float horizontalInput;
    private bool shouldJump;

    [Header("Delegates Creo")]

    public static Action salto;
    public static Action matar;



    private void OnEnable()
    {
        
        Player.salto += HandleJump;
    }

    private void OnDisable()
    {
        Player.salto -= HandleJump;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            salto?.Invoke();
            
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundCheckRadius,groundLayer);

        MoveCharacter();
    }

    void MoveCharacter()
    {
        Vector3 targetVelocity = new Vector3(horizontalInput * moveSpeed,rb.linearVelocity.y,0f);

        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity,targetVelocity,Time.fixedDeltaTime * 10f);
    }

    void HandleJump()
    {
        shouldJump = true;
        if (shouldJump)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x,jumpForce,rb.linearVelocity.z);
            shouldJump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            matar?.Invoke();

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}