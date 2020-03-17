using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiDeathScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Canvas_deathMenu;
    private static bool gameOver = false;
    private GameObject plane;
    private string tagName = rbPointCounter_script.PlaneTag();
    private GameObject inGameUI;

    void Start()
    {
        Canvas_deathMenu = this.gameObject;
        plane = GameObject.FindWithTag(tagName);
        inGameUI = GameObject.FindWithTag("InGameUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealthSystem.CurrentLives() <= 0)
        {
            plane.SetActive(false);
            inGameUI.SetActive(false);
            Time.timeScale = 0f;
            Canvas_deathMenu.SetActive(true);
            gameOver = true;

        }
        else
        {
            Time.timeScale = 1f;
            Canvas_deathMenu.SetActive(false);
            gameOver = false;
        }
    }
    public void GameRestart()
    {
        scoreHandler_script.ResetPoints();
        playerHealthSystem.SetLives();
        customUIButtonHandler.PlayGame();
   
    }

    public void OpenOptionsMenu()
    {

    }

    public void ReturnToMenu()
    {
        scoreHandler_script.ResetPoints();
        playerHealthSystem.SetLives();
        SceneManager.LoadScene(0);
    }
    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public static bool GameIsOver()
    {
        return gameOver;
    }
}
