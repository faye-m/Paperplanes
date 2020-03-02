using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFocus : MonoBehaviour
{
    private Transform focusOn;
    private Vector3 desiredPosition;
    private float offset = 0.45f;
    private float distance = 0.015f;
    private bool planeisLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        focusOn = GameObject.FindGameObjectWithTag(rbPointCounter_script.PlaneTag()).transform;
    }

    // Update is called once per frame
    void Update()
    {

        //checks if boolean planeisLaunched is true (paper plane has been launched) before camera is set to follow the player's movements
        if (planeisLaunched)
        {
            focusOn = GameObject.FindGameObjectWithTag(rbPointCounter_script.PlaneTag()).transform;
            
            //update the camera position according to the player location
            if (transform.position.y >= 2.5f)
            {
                desiredPosition = focusOn.position + (-transform.forward * distance) + (transform.up * offset * 0.05f);
            }

            else
            {
                desiredPosition = focusOn.position + (-transform.forward * distance) + (transform.up * offset);
            }

            //desiredPosition = focusOn.position + (-transform.forward * distance) + (transform.up * offset);

            //smoothing camera movement
            transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.05f);

            //Update camera rotation according to
            transform.LookAt((focusOn.position + Vector3.up * offset));
            print(transform.position);
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
