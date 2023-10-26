using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverMenu;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Shows the game over screen upon player's death
        if(playerHealth.dead == true)
        {
            gameOver();
        }
    }

    // Shows the game over screen
    public void gameOver()
    {
        gameOverMenu.SetActive(true);
    }
}
