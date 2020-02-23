using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLevel : MonoBehaviour
{
    public int levelGenerate;
    void Update()
    {
        
        if (Input.GetKeyDown("e"))
        {
            LoadTheLevel();
        }
    }
    public void LoadTheLevel()
    {
        levelGenerate = Random.Range(1, 5);
        SceneManager.LoadScene(levelGenerate);

    }
 
}


