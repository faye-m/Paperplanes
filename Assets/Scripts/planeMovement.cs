using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMovement : MonoBehaviour
{
    //variables for paper plane movement
    private CharacterController paperPlaneController;
    private float movementSpeed = 3f;
    private float rotXSpeed = 3.0f;
    private float rotYSpeed = -1.5f;
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

    private bool isInverted;

    // Start is called before the first frame update
    void Start()
    {
        paperPlaneController = GetComponent<CharacterController>(); // gets the character controller component attatched to player and sets it to the variable

        paperPlaneController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (PauseMenu.PauseTheGame())
        {

        }

        else
        {
            //calls the local paper plane functions on void update
            PaperPlaneLaunch();

            isInverted = UIOptionsMenu.GetBoolean();
        }

    }

    //function locking the paper plane's movement in place until spacebar is pressed
    private void PaperPlaneLaunch()
    {
        // checks if the boolean isLaunched is true and calls the PaperPlaneMovement() function when it is
        if (isLaunched)
        { 
            PaperPlaneMovement();
            
        } 

        //if function is not true (set to false), this code gets called
        else
        {
            //locks plane in current spawn position until launch and does not allow any arrow key movement in place
            //argument checks if the player has not yet launched the plane and makes sure that adding force to the plane's movement happens only once by
            //setting the isLaunched to true
            if (Input.GetKeyDown("space") && !isLaunched && !uiDeathScreen.GameIsOver())
            {
                isLaunched = true;
                PaperPlaneMovement();
            }
        }
    }

    //calls paper plane movement function, script made according to https://youtu.be/u7xxxwDCxC8 with changes made in order to make the game for PC rather than Android or iOS
    //Code is also modified to fit the mechanics of the game
    private void PaperPlaneMovement()
    {
        // gives player forward velocity
        moveVector = transform.forward * movementSpeed;

        //Get delta direction

        yaw = Input.GetAxis("Horizontal") * transform.right * rotXSpeed * Time.deltaTime;

        //simulates some form of gravity to the paper plane's movements
        //when the up key (up arrow, or w key, etc.) is pressed, plane move up
        if (Input.GetAxis("Vertical") > 0 && isInverted)
        {
            pitch = Input.GetAxis("Vertical") * transform.up * rotYSpeed * Time.deltaTime * fallSpeed * 2;
        }

        //when the down key (down arrow, or s key, etc.) is pressed, plane moves dives down faster than when no keys are pressed
        else if (Input.GetAxis("Vertical") < 0 && isInverted)
        {
            pitch = Input.GetAxis("Vertical") * transform.up * rotYSpeed * Time.deltaTime;
        }

        else if (Input.GetAxis("Vertical") > 0 && !isInverted)
        {
            pitch = Input.GetAxis("Vertical") * transform.up * -rotYSpeed * Time.deltaTime;
            print("up");
        }

        else if (Input.GetAxis("Vertical") < 0 && !isInverted)
        {
            pitch = Input.GetAxis("Vertical") * transform.up * -rotYSpeed * Time.deltaTime * fallSpeed * 2;
            print("down");
        }

        //when neither up nor down keys are pressed, the plane dips to the ground
        else 
        {
            pitch = transform.up * -fallSpeed * Time.deltaTime;
        }

        direction = yaw + pitch;

        //limits player from doing a loop and tilting too high up (prevents player from easily getting back their altitude)

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
        paperPlaneController.Move(moveVector * Time.deltaTime);

        // calls the plane's tilting functions (which is on the actual paperplane object rather than the player game object)
        PlaneTilt();
        
    }

    // gives the plane a tilt on the Z axis to better simulate a paper plane's movements
    private void PlaneTilt()
    {
        //checks if the right and left buttons are being pressed (value is not 0) and tilts plane accordingly
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            //set rotation Z speed based on the negative of the current horizontal axis
            rotZSpeed = -Input.GetAxis("Horizontal") * Time.deltaTime * 45f;

            //stores a total current rotation to check if it is over the current angle clamp value
            totalRotZ += rotZSpeed;

            //if current rotation is greater than or equal to the positive clamp value or less than the negative clamp value, rotation clamps to current value
            if (totalRotZ >= zClampVal || totalRotZ <= -zClampVal)
            {
                paperPlaneGObj.transform.Rotate(0, 0, 0);

                //sets the total rotation equal to the clamp value so that the plane does not get stuck in the clamped angle
                if (totalRotZ >=zClampVal)
                {
                    totalRotZ = zClampVal;
                }

                else
                {
                    totalRotZ = -zClampVal;
                }
                
            }

            //if current rotation has not reached the clamp value, tilt the plane according to the rotation z set
            else
            {
                
                paperPlaneGObj.transform.Rotate(0, 0, rotZSpeed);
            }

        }

        //if the left and right buttons are not being pressed, code sets the plane's z rotation back to 0 over time
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
