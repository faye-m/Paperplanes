using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class scoreHandler_script : MonoBehaviour
{
    private Text scoreValue;
    private static int  score = 0;
    // Start is called before the first frame update
    void Start()
    {
        //gets the text component in the object and sets it to the scoreValue variable
        scoreValue = GetComponent<Text>();  
    }

    // Update is called once per frame
    void Update()
    {
        //updates the text to whatever the player's current score is;
        scoreValue.text = "" + score;
    }

    public static void AddPoints ()
    {
        score++;
    }

    public static void ResetPoints ()
    {
        score = 0;
    }

    


}
