using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{   
    public Collider2D hitbox;

    // Damages enemy when coliding with attack's hitbox
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            health.damaged(10);
            Debug.Log("Enemy hit");
        }
    }

}
