using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oobjOnHit_script : MonoBehaviour
{
    private static string tagName = rbPointCounter_script.PlaneTag(); //instantiates the same string tag from rbPointCounter_script, changes made to tagName string on that file will reflect here as well
    private static int totalScore;
    private static int resetScore = 0;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function that checks if the object that enters is tagged "Player" and will trigger the game over functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag==tagName)
        {
            
            totalScore = rbPointCounter_script.ScoreTotal(); //sets totalScore to current total recorded in rbPointCounter_script by calling the function
            print("Game Over!");
            print(totalScore);
            
            totalScore = rbPointCounter_script.SetScoreTotal(resetScore); //resets the current score back to 0 by calling the function in the referenced script
            print("Reset Score: " + totalScore);
            
            planeMovement_script.SetLaunchSpeed();
            RandomLevel.LoadTheLevel();
        }
    }
}
