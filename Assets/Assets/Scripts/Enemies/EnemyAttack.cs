using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Collider2D hitbox;

    // Damages player when attack hitbox collides with them
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            health.damaged(10);
            Debug.Log("Player hit");
        }
    }
}
