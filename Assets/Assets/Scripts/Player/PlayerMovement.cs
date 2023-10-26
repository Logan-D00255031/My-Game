using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    // Original code from pratical classes and modified for personal use
    public float speed = 10f;
    public float jumpHeight = 7f;
    private Rigidbody2D body;
    private Animator playerAnim;
    public bool playerIsGrounded;
    private bool attacking = false;
    private bool facingRight = true;
    public PlayerHealth health;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Allows animator to play attack animations while input is active and player is on the ground
        if(Input.GetKey(KeyCode.Mouse0) && playerIsGrounded)
        {
            attacking = true;
            playerAnim.SetBool("Attack", true);
        }
        else
        {
            attacking = false;
            playerAnim.SetBool("Attack", false);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput =  Input.GetAxisRaw("Horizontal");

        // Player can only move if they are alive
        if(health.dead == false)
        {   
            // Player cannot run while attacking
            if (!attacking)
            {
                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
                playerAnim.SetFloat("Speed", Mathf.Abs(horizontalInput));
            }
            else
            {
                body.velocity = new Vector2(0 * speed, body.velocity.y);
                playerAnim.SetFloat("Speed", 0);
            }

            // Flips character based on horizontal input
            if((horizontalInput > 0 && !facingRight)|| (horizontalInput < 0 && facingRight))
            {
                Flip();
            }

            if(Input.GetKey(KeyCode.Space) && playerIsGrounded)
            {
                Jump();
            }
        }
        
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        playerAnim.SetTrigger("Jump");
        playerAnim.SetBool("Grounded", false);
        playerIsGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground"))
        playerAnim.SetBool("Grounded", true);
        playerIsGrounded = true;
        Debug.Log("Player has landed on the ground");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            playerAnim.SetBool("Grounded", false);
            playerIsGrounded = false;
            Debug.Log("Player has left the ground");
        }
        
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight; 
    }

    
}
