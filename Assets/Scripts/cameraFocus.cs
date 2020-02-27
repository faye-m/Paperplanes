﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFocus : MonoBehaviour
{
    public Transform focusOn;
    private Vector3 desiredPosition;
    private float offset = 0.45f;
    private float distance = 0.015f;
    private bool planeisLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //checks if boolean planeisLaunched is true (paper plane has been launched) before camera is set to follow the player's movements
        if (planeisLaunched)
        {
            //update the camera position according to the player location
            desiredPosition = focusOn.position + (-transform.forward * distance) + (transform.up * offset);

            //smoothing camera movement
            transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.05f);

            //Update camera rotation according to
            transform.LookAt((focusOn.position + Vector3.up * offset));
        }
        
        //if plane has not been launched yet, camera stays in fixed position
        else
        {
            //if space bar is pressed and planeisLaunched is false, set planeisLaunched to true
            if (Input.GetKeyDown("space") && !planeisLaunched)
            {
                planeisLaunched = true;
            }
        }
    }
}
