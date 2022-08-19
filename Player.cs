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



    void Start()
    {
        isGrounded = false;
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
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
        playerRb.AddTorque(torqueForce * horizontalInput * Time.deltaTime,ForceMode2D.Impulse);
    }
    void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            playerRb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
