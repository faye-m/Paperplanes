using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class playerHealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private Text pLivesValue;
    private static int lives = 3;
    private static bool wasTriggered = false;
    

    void Start()
    {
        pLivesValue = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        pLivesValue.text = "" + lives;
    }

    public static void DecreaseLifeBar()
    {
        lives--;
    }

    public static void ResetChecker()
    {
        if (lives > 0)
        {
            //insert reset level script
            DecreaseLifeBar();
            wasTriggered = true;
            RandomLevel.ReloadCurrentLevel();
            if (lives > 0)
            {
                
                scoreHandler_script.ResetCurrentLevelScore();
                wasTriggered = false;
                
            }
             else if (lives <= 0)
            {
                //scoreHandler_script.ResetPoints();
                scoreHandler_script.ResetRingScore();
                lives = 0;
                wasTriggered = false;
                //SetLives();
                //RandomLevel.LoadTheLevel();
            }
        } 

        else if (lives <= 0)
        {
            lives = 0;
            wasTriggered = false;
            scoreHandler_script.ResetPoints();
            scoreHandler_script.ResetRingScore();
        }

        else
        {
            scoreHandler_script.ResetPoints();
            scoreHandler_script.ResetRingScore();
            //SetLives();
            //RandomLevel.LoadTheLevel();
        }

    }

    public static void SetLives()
    {
        lives = 3;
    }

    public static int CurrentLives()
    {
        return lives;
    }


}
