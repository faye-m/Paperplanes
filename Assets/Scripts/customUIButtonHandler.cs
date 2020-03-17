using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customUIButtonHandler : MonoBehaviour
{
    private Text Startkey;
    private bool spacePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        Startkey= GetComponent<Text>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || spacePressed)
        {
            Startkey.text = "";
            spacePressed = true;
        }

        else
        {
            Startkey.text = "Press SPACE to start!";
        }
    }

    public static void PlayGame()
    {
        playerHealthSystem.SetLives();
        RandomLevel.LoadTheLevel();

        print("PLAY");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void StartGame()
    {
        playerHealthSystem.SetLives();
        RandomLevel.LoadTheLevel();
    }

    public static void SpaceToStart()
    {
        //Startkey.SetActive(false);

    }
}
