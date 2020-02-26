﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbPointCounter_script : MonoBehaviour
{
    //variables called and set at the start to remove as much hard coded values from the code so that editing these values will be easier
    //variables are set to private to prevent too easy access to the data for security reasons, variables that will need to be referenced in another script will be made accessible
    //through a public function
    private static int score = 0;
    private static string tagName = "Player";
    private GameObject player;
    private static int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //code checks if the object that enters the trigger area is tagged as "Player" and adds points accordingly
        if (other.gameObject.tag==tagName)
        {
            
            score = SetScoreTotal(score);
            score += 1;
            score = SetScoreTotal(score);
            print("Score:    " + score);
            
            
            planeMovement_script.SetLaunchSpeed();
            RandomLevel.LoadTheLevel();
        }
    }

    //function that stores the value and calls the private score variable and makes it accessible to other scripts
    // function needs to return an int value
    public static int SetScoreTotal ( int x)
    {
        currentScore = x;
        return currentScore;
    }

    //function that stores the string and calls the private tagName variable and makes it accessible to other scripts
    public static string PlaneTag ()
    {
        return tagName;
    }

    public static int ScoreTotal()
    {
        return currentScore;
    }
}