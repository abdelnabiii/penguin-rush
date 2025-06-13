using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class playermvmnt : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform character;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDist = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private bool isJumpPressed;
    private float jumpTimer;
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDist, groundLayer);


        if (isJumping && isJumpPressed)
        {
            if(jumpTimer < jumpTime)
            {
                rb.velocity = (Vector2.up * jumpForce * Time.deltaTime);
                jumpTimer += Time.deltaTime;
            } else
            {
                rb.velocity += ((Vector2.down * jumpForce * 50) * Time.deltaTime);
                isJumping = false;
            }

        }

        
    }

    public void JumpDown() {
        if (isGrounded)
        {
            jumpTimer = 0.0f;
            Debug.Log("Jump pressed Down");
            isJumping = true;
            isJumpPressed = true;
            rb.velocity = Vector2.up * jumpForce;
        }

    }
    public void JupmUp() {
        Debug.Log("Jump Pressed Up");
        isJumpPressed = false;
    }
}

