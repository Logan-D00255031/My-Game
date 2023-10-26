using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Original code found from video: https://youtu.be/9dYDBomQpBQ?si=LHbQ3SKWoNMUFCgB
    public GameObject pauseMenu;
    public bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    // Pauses the game
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    // Resumes the game
    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    // Exits to the main menu
    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        gamePaused = false;
    }

    //Closes the game
    public void quitGame()
    {
        Application.Quit();
    }
}
