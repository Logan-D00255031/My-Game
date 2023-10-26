using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 2f;
    private bool facingRight = true;
    public bool canMove = true;
    private Rigidbody2D body;
    private Animator anim;
    private float lastLocation;
    private float currentLocation;
    public PlayerHealth health;
    public EnemySpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Stops enemies movement and allows another to spawn
        if(health.dead)
        {
            canMove = false;
            spawner.EnemyDied();
        }
    }

    void FixedUpdate()
    {
        // Original code found from video: https://youtube.com/shorts/eZBm-VNAYDA?si=BajII_WzdOjaLcnO
        lastLocation = transform.position.x;

        if(canMove)
        {
            if(player.transform.position.x > transform.position.x)
            {
                body.velocity = new Vector2(speed, body.velocity.y);
                if(!facingRight)
                {
                    Flip();
                }
            }
            else if(player.transform.position.x < transform.position.x)
            {
                body.velocity = new Vector2(-1 * speed, body.velocity.y);
                if(facingRight)
                {
                    Flip();
                }
            }
        }
        else
        {
            body.velocity = new Vector2(0 * speed, body.velocity.y);
            anim.SetFloat("Speed", 0);
        }

        anim.SetFloat("Speed", Mathf.Abs(currentLocation - lastLocation));
    }

    //Same flip code from PlayerMovement
    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight; 
    }
}
