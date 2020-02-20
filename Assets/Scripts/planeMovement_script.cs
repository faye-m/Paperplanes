using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMovement_script : MonoBehaviour
{
    private float movX = 0;
    private float movY = 0;
    private float movZ = 0;
    private float movementSpeed = 5f;
    private float horizontalTilt = 0;
    private float tiltMagnitude = 45f;
    private float currentTilt = 0f;
    private float clampAngle = 60f;
    private float easeBack = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        

        if (Input.GetKey("right") || Input.GetKey("left"))
        {
            transform.position = transform.position + new Vector3(movX, 0, 0);
            horizontalTilt = -movX * tiltMagnitude;

            currentTilt += horizontalTilt;

            if (currentTilt >= clampAngle || currentTilt <= -clampAngle)
            {
                gameObject.transform.Rotate(0,0,0);

                if (currentTilt >= clampAngle)
                {
                    currentTilt = clampAngle;
                }

                else
                {
                    currentTilt = -clampAngle;
                }
            }

            else
            {
                gameObject.transform.Rotate(0, 0, horizontalTilt);
            }

            print("Current Tilt:  " + currentTilt);
        }

        else
        {
            
            if (currentTilt < 0)
            {
                currentTilt += easeBack;
                gameObject.transform.Rotate(0, 0, easeBack);
            }

            else if (currentTilt > 0)
            {
                currentTilt -= easeBack;
                gameObject.transform.Rotate(0, 0, -easeBack);
            }

        }

        
    }
}
