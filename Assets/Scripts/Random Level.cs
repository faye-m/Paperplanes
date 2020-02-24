using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLevel : MonoBehaviour
{
    public static int levelGenerate;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        if (Input.GetKeyDown("e"))
        {
            LoadTheLevel();
        }
    }
    public static void LoadTheLevel()
    {
        levelGenerate = Random.Range(1, 5);
        SceneManager.LoadScene(levelGenerate);

    }
 
}


