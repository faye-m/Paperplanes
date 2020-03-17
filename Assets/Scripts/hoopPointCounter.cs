using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoopPointCounter : MonoBehaviour
{
    private string tagName = rbPointCounter_script.PlaneTag(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagName || other.gameObject.tag == "Plane")
        {
            //calls the functions made public on different scripts
            scoreHandler_script.RingAddPoints();
            Destroy(gameObject);
        }
    }
}
