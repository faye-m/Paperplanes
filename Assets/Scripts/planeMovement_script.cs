using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMovement_script : MonoBehaviour
{

    //main variables called for plane movement
    private float rotY = 0f;
    private float rotX = 0f;
    private float rotZ = 0f;
    private float movementSpeed = 5f;
    private float angleMagnitude = 7f;
    private float roundDown = 0f;
    private float remainder = 0f;

    private float totalRotX = 0f;
    private float totalRotY = 0f;
    private float totalRotZ = 0f;

    private float clampAngle = 45f;

    private float timeElapsed = 0f;
    private bool isSubtracted = false;

    public GameObject gobj_paperPlane;
    private Vector3 ppPosition;
    

    //main variables called for plane launch function
    public Rigidbody rb_paperPlane;
    private bool isLaunched = false;
    private static float launchSpeed = 3f;


    // Start is called before the first frame update
    void Start()
    {
        rb_paperPlane = GetComponent<Rigidbody>(); //initiates rigidBody at start
        gobj_paperPlane = GetComponent<GameObject>();
        ppPosition = gobj_paperPlane.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlaneLaunch(); // calls the launching function
        PlaneMovement(); // calls the plane movement function
        
    }

    private void PlaneMovement ()
    {

        if (isLaunched)
        {
            timeElapsed += Time.deltaTime;
            roundDown = Mathf.Round(timeElapsed);
            remainder = roundDown % 15;
            

            if ( remainder == 0 && !isSubtracted)
            {
                launchSpeed -= 2;
                isSubtracted = true;
            }

            if (remainder != 0 && isSubtracted)
            {
                isSubtracted = false;
            }

            if (launchSpeed <= 0)
            {
                launchSpeed = 0;
            }

            print("Launch Speed:   " + launchSpeed + "   |      Time Elapsed:   " + timeElapsed + "   |      Rounded Down:   " + roundDown + "   |      Remainder:   " + remainder);

            rb_paperPlane.velocity = transform.forward * launchSpeed;

            if (Input.GetKey("left") || Input.GetKey("right"))
            {
                rotY = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime * angleMagnitude;
                rotZ = -rotY;

                totalRotY += rotY;
                totalRotZ += rotZ;

                //ClampPlaneRotation();


                gameObject.transform.Rotate(0, rotY, rotZ);
            }

            if (Input.GetKey("up") || Input.GetKey("down"))
            {
                rotX = -Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime * angleMagnitude;

                totalRotX += rotX;

                //ClampPlaneRotation();

                gameObject.transform.Rotate(rotX, 0, 0);
            }
        }

        else
        {
            if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("down") || Input.GetKey("up"))
            {
                print("Press the SPACEBAR to launch first!");
            }

            else if (isLaunched)
            {
                print("Can't speed up further!");
            }
        }
        

    }

    private void ClampPlaneRotation ()
    {
        if (totalRotX < -clampAngle || totalRotX > clampAngle)
        {
            rotX = 0;

            if (totalRotX < -clampAngle)
            {
                totalRotX = -clampAngle;
            }

            else
            {
                totalRotX = clampAngle;
            }
        }

        if (totalRotY < -clampAngle || totalRotY > clampAngle)
        {
            rotY = 0;

            if (totalRotY < -clampAngle)
            {
                totalRotY = -clampAngle;
            }

            else
            {
                totalRotY = clampAngle;
            }
        }

        if (totalRotZ < -clampAngle || totalRotZ > clampAngle)
        {
            rotZ = 0;

            if (totalRotZ < -clampAngle)
            {
                totalRotZ = -clampAngle;
            }

            else
            {
                totalRotZ = clampAngle;
            }
        }
    }

    //function that handles the plane's launch
    private void PlaneLaunch()
    {
        if (isLaunched)
        {
           
        }

        else
        {
            //locks plane in current spawn position until launch;
            transform.position = new Vector3(5.437f,1.88f,-0.789f);

            //argument checks if the player has not yet launched the plane and makes sure that adding force to the plane's movement happens only once by
            //setting the isLaunched to true
            if (Input.GetKeyDown("space") && !isLaunched)
            {
                print("spacebar pressed");
                isLaunched = true;
                rb_paperPlane.velocity = transform.forward * launchSpeed;
            }
        }
    }

    public static float SetLaunchSpeed ()
    {
        launchSpeed = 3f;
        return launchSpeed;
    }

    private void ResetDefaultRotation()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    //function that handles the plane's movements
    /*private void PlaneMovement()
    {
        movX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime; // moves the plane left and right according to the input axis

        //argument checks if the plane has been launched before allowing movement
        if (isLaunched)
        {
            //argument that gives the plane a rotation to tilt at based on what direction it is heading towards by checking if the input being pressed is true
            if (Input.GetKey("right") || Input.GetKey("left"))
            {
                paperPlane.velocity = transform.forward * launchSpeed * Time.deltaTime;
                planeTilt = -movX * tiltMagnitude;
                

                currentTilt += planeTilt;
                

                // argument that checks for if the plane's current tilt angle is over or under a specific range value and clamps the angle to the desired value
                if (currentTilt >= clampAngle || currentTilt <= -clampAngle)
                {
                    gameObject.transform.Rotate(0, 0, 0);
                    

                    if (currentTilt >= clampAngle)
                    {
                        currentTilt = clampAngle;
                    }

                    else
                    {
                        currentTilt = -clampAngle;
                    }
                }

                //argument that activates as long as the plane is not at its max desired angle and rotates the plane according to the horizontalTilt value
                else
                {
                    gameObject.transform.Rotate(0, 0, planeTilt);
                    
                }

                print("Current Tilt:  " + currentTilt);
            }

            //argument that resets the plane's rotation back to 0 over time when the button is not being pressed
            else
            {

                if (currentTilt < 0)
                {
                    currentTilt += easeBack;
                    gameObject.transform.Rotate(0, 0, easeBack);
                    print("+++");

                    if (currentTilt >= 0)
                    {
                        currentTilt = 0;
                        ResetDefaultRotation();
                    }
                }

                else if (currentTilt > 0)
                {
                    currentTilt -= easeBack;
                    gameObject.transform.Rotate(0, 0, -easeBack);
                    print("---");

                    if (currentTilt <= 0)
                    {
                        currentTilt = 0;
                        ResetDefaultRotation();
                    }
                }


            }
        }
        
    }*/


}
