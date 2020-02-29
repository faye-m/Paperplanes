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
        if (lives <= 0)
        {
            SetLives();
            RandomLevel.LoadTheLevel();
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
