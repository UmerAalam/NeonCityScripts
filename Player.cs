using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] KeyCode jumpKey;
    [SerializeField] float moveSpeed;
    [SerializeField] float flySpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float torqueForce;
    [SerializeField] Rigidbody2D playerRb;
    float horizontalInput,verticalInput;
    bool isGrounded;
    bool canFly;
    bool flyMode;
    bool normalMode;
    bool canMove;


    void Start()
    {
        canMove = true;
        canFly = false;
        isGrounded = false;
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        CheckFlyMode();
        CheckCanFly();
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        Movement();
        Jump();
    }
    void Movement()
    {
        if(canMove)
        {
        playerRb.gravityScale = 2f;
        playerRb.AddForce(Vector2.right * moveSpeed * horizontalInput * Time.deltaTime,ForceMode2D.Impulse);
        playerRb.AddTorque(torqueForce * horizontalInput * Time.deltaTime, ForceMode2D.Impulse);
        }
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
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Stairs"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.transform.name == "WingSuit")
        {
            Destroy(collision.gameObject);
            canFly = true;
        }
    }
    void CheckCanFly()
    {
        if (!canFly)
            return;
        else
        {
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                flyMode = true;
                canMove = false;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                canMove = true;
                flyMode = false;
            }
        }
    }
    void CheckFlyMode()
    {
        if(flyMode)
        {
            FlyMode();
        }
    }
    void FlyMode()
    {
        playerRb.gravityScale = 0f;
        Vector2 moveDirection = Vector2.up * verticalInput + Vector2.right * horizontalInput;
        playerRb.AddForce(moveDirection.normalized * flySpeed);
    }
}

