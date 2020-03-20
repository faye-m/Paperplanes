using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private static bool isInverted = true;
    private Toggle invertedToggle;
    void Start()
    {
        invertedToggle = GetComponent<Toggle>();
        invertedToggle.onValueChanged.AddListener(delegate { ToggleValueChanged(invertedToggle);});
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invertedToggle.isOn)
        {
            isInverted = true;
            print("TRUE");
        }

        else if (!invertedToggle.isOn)
        {
            isInverted = false;
            print("FALSE");
        }
    }

    private void ToggleValueChanged(Toggle change)
    {
        print("Toggled Value Changed To: " + invertedToggle.isOn);
    }

    public void highscorereset()
    {
        highScoreScript.ResetHighScore();
    }

    public static bool GetBoolean()
    {
        return isInverted;
    }

    public void  InvertTheControls()
    {
       
    }

}
