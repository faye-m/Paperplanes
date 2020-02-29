using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbPointCounter_script : MonoBehaviour
{
    //variables called and set at the start to remove as much hard coded values from the code so that editing these values will be easier
    //variables are set to private to prevent too easy access to the data for security reasons, variables that will need to be referenced in another script will be made accessible
    //through a public function 
    private static string tagName = "Player";
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //code checks if the object that enters the trigger area is tagged as "Player" and adds points accordingly
        if (other.gameObject.tag==tagName)
        {
            //calls the functions made public on different scripts
            scoreHandler_script.BinAddPoints();
            playerHealthSystem.SetLives();
            RandomLevel.LoadTheLevel();
            scoreHandler_script.ResetRingScore();
        }
    }

    //function that stores the string and calls the private tagName variable and makes it accessible to other scripts
    public static string PlaneTag ()
    {
        return tagName;
    }

}
