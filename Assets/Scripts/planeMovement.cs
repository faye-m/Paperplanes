using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMovement : MonoBehaviour
{
    //variables for paper plane movement
    private CharacterController paperPlaneController;
    private Rigidbody rbPaperPlane;
    private float movementSpeed = 3f;
    private float rotXSpeed = 3.0f;
    private float rotYSpeed = 1.5f;
    private Vector3 moveVector;
    private Vector3 yaw;
    private Vector3 pitch;
    private Vector3 direction;
    private float maxX;
    private float fallSpeed = 1.5f;

    //variables called for plane launch function
    private bool isLaunched = false;

    //variables called for plane tilt function
    public GameObject paperPlaneGObj;
    private float rotZSpeed;
    private float totalRotZ;
    private float zClampVal = 45f;

    // Start is called before the first frame update
    void Start()
    {
        paperPlaneController = GetComponent<CharacterController>();
        rbPaperPlane = GetComponent<Rigidbody>();
        //paperPlaneGObj = GetComponent<GameObject>();

        paperPlaneController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        PaperPlaneLaunch();
    }

    private void PaperPlaneLaunch()
    {
        if (isLaunched)
        { 
            PaperPlaneMovement();
        }

        else
        {
            //locks plane in current spawn position until launch;
            //transform.position = new Vector3(9.12f, 1.245f, -0.612f);

            //argument checks if the player has not yet launched the plane and makes sure that adding force to the plane's movement happens only once by
            //setting the isLaunched to true
            if (Input.GetKeyDown("space") && !isLaunched)
            {
                print("spacebar pressed");
                isLaunched = true;
                PaperPlaneMovement();
            }
        }
    }

    //calls paper plane movement function, script made according to https://youtu.be/u7xxxwDCxC8
    private void PaperPlaneMovement()
    {
        // gives player forward velocity
        moveVector = transform.forward * movementSpeed;

        //Get delta direction

        yaw = Input.GetAxis("Horizontal") * transform.right * rotXSpeed * Time.deltaTime;

        if (Input.GetAxis("Vertical") > 0)
        {
            pitch = Input.GetAxis("Vertical") * transform.up * rotYSpeed * Time.deltaTime;
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            pitch = Input.GetAxis("Vertical") * transform.up * rotYSpeed * Time.deltaTime * fallSpeed * 2;
        }

        else 
        {
            pitch = transform.up * -fallSpeed * Time.deltaTime;
        }

        direction = yaw + pitch;

        //limits player from doing a loop

        maxX = Quaternion.LookRotation(moveVector + direction).eulerAngles.x;

        if (maxX < 90 && maxX > 70 || maxX > 300 && maxX < 330)
        {
            //going too far!
        }

        else
        {
            //add direction to current movement
            moveVector += direction;

            // player faces where they are going

            transform.rotation = Quaternion.LookRotation(moveVector);
        }

        // move player
        print("Move Vector:   " + moveVector + "   | Max X:   " + maxX);
        paperPlaneController.Move(moveVector * Time.deltaTime);
        PlaneTilt();
        
    }

    private void PlaneTilt()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            rotZSpeed = -Input.GetAxis("Horizontal") * Time.deltaTime * 45f;
            totalRotZ += rotZSpeed;

            if (totalRotZ >= zClampVal || totalRotZ <= -zClampVal)
            {
                paperPlaneGObj.transform.Rotate(0, 0, 0);

                if (totalRotZ >=zClampVal)
                {
                    totalRotZ = zClampVal;
                }

                else
                {
                    totalRotZ = -zClampVal;
                }
                
            }

            else
            {
                
                paperPlaneGObj.transform.Rotate(0, 0, rotZSpeed);
            }

            
            print(totalRotZ);
        }

        else 
        { 
            if (totalRotZ > 0)
            {
                totalRotZ -= 0.5f;
                paperPlaneGObj.transform.Rotate(0, 0, -0.5f);

                if (totalRotZ < 1)
                {
                    paperPlaneGObj.transform.localEulerAngles = new Vector3(0, 0, 0);
                    totalRotZ = 0;
                }
            }

            else if (totalRotZ < 0)
            {
                totalRotZ += 0.5f;
                paperPlaneGObj.transform.Rotate(0, 0, 0.5f);

                if (totalRotZ > -1)
                {
                    paperPlaneGObj.transform.localEulerAngles = new Vector3(0, 0, 0);
                    totalRotZ = 0;
                }
            }

        }
    }
}
