using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public Collider2D collide;
    public Animator anim;
    public EnemyMovement movement;

    // Checks if the player is within the hitbox range
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Attack", true);
            Debug.Log("Player is in range");
            movement.canMove = false;
        }
    }

    // Checks if the player has left the hitbox range
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Attack", false);
            Debug.Log("Player is no longer in range");
            movement.canMove = true;
        }
    }
}
