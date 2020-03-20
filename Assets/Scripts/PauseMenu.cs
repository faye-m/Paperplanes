using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

  
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ReturnToMenu()
    {
        playerHealthSystem.SetLives();

        scoreHandler_script.ResetRingScore();

        scoreHandler_script.ResetPoints();
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        playerHealthSystem.SetLives();

        scoreHandler_script.ResetRingScore();

        scoreHandler_script.ResetPoints();

        RandomLevel.ReloadCurrentLevel();

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public static  bool PauseTheGame()
    {
        return GameIsPaused;
    }
}
