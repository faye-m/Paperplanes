﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oobjOnHit_script : MonoBehaviour
{
    private static string tagName = rbPointCounter_script.PlaneTag(); //instantiates the same string tag from rbPointCounter_script, changes made to tagName string on that file will reflect here as well
    private int lives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lives = playerHealthSystem.CurrentLives();
    }

    //function that checks if the object that enters is tagged "Player" and will trigger the game over functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag==tagName || other.gameObject.tag == "Plane")
        {
            //calls the functions made public on different scripts

            playerHealthSystem.ResetChecker();
            
        }
    }
}
