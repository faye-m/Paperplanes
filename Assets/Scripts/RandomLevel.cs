using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLevel : MonoBehaviour
{
    //variables and functions are set to static so that they can be called in other functions
    public static int levelGenerate;
    public static int currentLevel;
    

    private void Start()
    {
        
    }

    private void Update()
    {
        
        

    }
    public static void LoadTheLevel()
    {
        levelGenerate = Random.Range(1, 4);

        //checks for if level generated is not the same, if it is the same as the current level, it runs the while loop until the value changes
        while (levelGenerate == currentLevel)
        {
            levelGenerate = Random.Range(1, 4);
        }

        SceneManager.LoadScene(levelGenerate);
        currentLevel = levelGenerate;
    }

    public static void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
 
}


