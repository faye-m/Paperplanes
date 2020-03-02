using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeGlideParticleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem windPSystem;
    private bool planeIsLaunched = false;
    
    void Start()
    {
        windPSystem = GetComponent<ParticleSystem>();
        windPSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (planeIsLaunched)
        {
            
        }

        else
        {
            if (Input.GetKeyDown("space") && !planeIsLaunched)
            {
                windPSystem.Play();
                planeIsLaunched = true;
            }
        }
    }
}
