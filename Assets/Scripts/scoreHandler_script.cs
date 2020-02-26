using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class scoreHandler_script : MonoBehaviour
{
    private Text scoreValue;
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = GetComponent<Text>();  
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = "" + rbPointCounter_script.ScoreTotal();
    }

    


}
