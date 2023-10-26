using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Original code found from video: https://youtu.be/KtPxBe1f8Kg?si=LKizh4F5kYiSVJw9
    public Animator anim;
    public int health = 10;
    public bool dead = false;
    public bool invincible = false;
    private float timeSinceDamage = 0;
    public float invinciblityTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if(invincible)
        {
            // Disables invincibilty after time is up
            if(timeSinceDamage > invinciblityTime)
            {
                // Stop being invincible
                invincible = false;
                timeSinceDamage = 0;
            }

            timeSinceDamage += Time.deltaTime;
        }

        // Sets the Object to it's dead state
        if(health <= 0)
        {
            dead = true;
            anim.SetBool("Dead", true);
        }

        //damaged(10);
    }

    // Damaging the Object
    public void damaged(int damage)
    {
        // Cannot damage while dead or invincible
        if(!dead && !invincible)
        {
            health -= damage;
            invincible = true;
            anim.SetTrigger("Hit");
            Debug.Log("Player took " + damage + " damage");
        }
    }
}
