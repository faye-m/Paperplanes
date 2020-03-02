using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlane : MonoBehaviour
{ // Start is called before the first frame update
    public new Rigidbody rigidbody;
    public float energy;
    public float fall;
    public float airspeed;
    public GameObject tiltometer;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Period))
            Time.timeScale *= 2;
        if (Input.GetKeyDown(KeyCode.Comma))
            Time.timeScale *= 2;
        energy = transform.position.y + rigidbody.velocity.magnitude;
    }
    void FixedUpdate()
    {
        float roll = Input.GetAxis("Horizontal");
        float tilt = Input.GetAxis("Vertical");

        float yaw = Input.GetAxis("Yaw") / 8;

        roll /= Time.timeScale;
        tilt /= Time.timeScale;
        yaw /= Time.timeScale;

        // Yaw based on how you roll
        float tip = Vector3.Dot(transform.right, Vector3.up);
        yaw -= tip;

        // Tip based on if you're going backwards
        if ((transform.forward + rigidbody.velocity.normalized).magnitude < 1.4)
            tilt += 0.3f;

        if (tilt != 0)
            transform.Rotate(transform.right, tilt * Time.deltaTime * 10, Space.World);
        if (roll != 0)
            transform.Rotate(transform.forward, roll * Time.deltaTime * -10, Space.World);
        if (yaw != 0)
            transform.Rotate(Vector3.up, yaw * Time.deltaTime * 15, Space.World);

        //Gravity
        rigidbody.velocity -= Vector3.up * Time.deltaTime;

        // Vertical (to the glider) velocity turns into horizontal velocity
        Vector3 vertvel = rigidbody.velocity - Vector3.ProjectOnPlane(transform.up, rigidbody.velocity);
        fall = vertvel.magnitude;
        rigidbody.velocity -= vertvel * Time.deltaTime;
        rigidbody.velocity += vertvel.magnitude * transform.forward * Time.deltaTime / 10;

        //Drag
        Vector3 forwardDrag = rigidbody.velocity - Vector3.ProjectOnPlane(transform.forward, rigidbody.velocity);

        Vector3 sideDrag = rigidbody.velocity - Vector3.ProjectOnPlane(transform.right, rigidbody.velocity);
        rigidbody.AddForce(-sideDrag * sideDrag.magnitude * Time.deltaTime);

        airspeed = rigidbody.velocity.magnitude;

        tiltometer.transform.rotation = Quaternion.LookRotation(Vector3.up);


    }
}
