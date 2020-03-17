using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class highScoreScript : MonoBehaviour
{
    private int score = 0;
    public static Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = GetComponent<Text>();
        //gets the previous high score from the last played game
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        HighScore();
    }
    public static void HighScore()
    {
        if (scoreHandler_script.GetCurrentScore() > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreHandler_script.GetCurrentScore());
            highScore.text = scoreHandler_script.GetCurrentScore().ToString();
        }
        
    }

    public static void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "0";
    }
}
