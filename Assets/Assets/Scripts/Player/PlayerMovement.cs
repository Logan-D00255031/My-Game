using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 7f;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool attacking = false;
    private bool facingRight = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput =  Input.GetAxisRaw("Horizontal");

        if (!attacking)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        }
        else
        {
            body.velocity = new Vector2(0 * speed, body.velocity.y);
            anim.SetFloat("Speed", 0);
        }

        if((horizontalInput > 0 && !facingRight)|| (horizontalInput < 0 && facingRight))
        {
            Flip();
        }
        

        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.E) && grounded)
        {
            attacking = true;
            anim.SetBool("Attack", true);
        }
        else
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }
        
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        anim.SetTrigger("Jump");
        anim.SetBool("Grounded", false);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground"))
        anim.SetBool("Grounded", true);
        grounded = true;
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight; 
    }


}
