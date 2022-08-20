using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] KeyCode jumpKey;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float torqueForce;
    [SerializeField] Rigidbody2D playerRb;
    float horizontalInput;
    bool isGrounded;
    float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundMask);
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        Movement();
        Jump();
    }
    void Movement()
    {
        playerRb.AddForce(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime,ForceMode2D.Impulse);
        playerRb.AddTorque(torqueForce * horizontalInput * Time.deltaTime, ForceMode2D.Impulse);
        if (isGrounded)
            torqueForce = 60f;
        else
            torqueForce = 0f;
    }
    void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            playerRb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }
}
