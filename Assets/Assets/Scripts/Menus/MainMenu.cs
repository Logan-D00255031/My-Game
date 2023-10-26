using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Original code found from video: https://youtu.be/zc8ac_qUXQY?si=7zsx2Dt5zFkPNCTo

    // Loads the game scene
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    // Closes the game
    public void quitGame()
    {
        Application.Quit();
    }
}

