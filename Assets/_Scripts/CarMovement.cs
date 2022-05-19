using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    /// <summary>
    /// This section will contain code for an AI as seen in this tutorial https://www.youtube.com/watch?v=vsPzo7IVTHw
    /// </summary>
    public enum AIMode {  followPlayer, followWaypoints };

    [Header("AI settings")]
    public AIMode aiMode;

    Vector3 targetPosition = Vector3.zero;
    Transform targetTransform = null;

    //movement variables
    public float driftFactor = 0.95f;
    public float acceleration =-30.0f;
    public float maxSpeed = 20; 
    public float turnSpeed =3.5f;

    float accelerationInput = 0;
    float turnSpeedInput = 0;

    float rotationAngle = 0;

    float velocityVsForward;

    private Rigidbody rb;

    ////variables for car turning
    //public Transform target; //targets the turn trigger obj
    //public float directionNumber;   //creates a variable to store number that indicates direction

    //animation



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //target = null;

        
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();

        ApplySteering();
        
        RemoveOrthagonalVelocity();
        //Vector2 inputVector = Vector2.zero;

        //send input to controller
        
    }

    void ApplyEngineForce()
    {
        velocityVsForward = Vector3.Dot(transform.forward, rb.velocity);       //returns how much "forward" car is going

        if (velocityVsForward > maxSpeed && accelerationInput > 0)
        {
            return;     //if max speed reached return from fn, more force is not applied
        }

        if (velocityVsForward < -maxSpeed * 0.5f && accelerationInput < 0)
        {
            return;     //if max speed reached return from fn, more force is not applied
        }

        if (accelerationInput == 0)
        {
            rb.drag = Mathf.Lerp(rb.drag, 3.0f, Time.fixedDeltaTime * 3);   //if there is no acceleration input, then add drag on to the rigidbody 
                                                                            //this slows car down and eventually stops it
        }
        else
        {
            rb.drag = 0;    //if there is acceleration input remove all drag

        }

        Vector3 engineForceVector = transform.forward * accelerationInput * acceleration;

        rb.AddForce(engineForceVector, ForceMode.Force);

    }

    void ApplySteering()
    {
        float minSpeedToAllowTurning = (rb.velocity.magnitude / 8);  //gives a minimum value of speed that needs to be reached before can turn

        minSpeedToAllowTurning = Mathf.Clamp01(minSpeedToAllowTurning);     //then clamps the variable to give a factor between 0and 1
                                                                            //so, if car speed is 0 then this variable will be 0


        rotationAngle -= turnSpeedInput * turnSpeed *minSpeedToAllowTurning;    //multiplying by minspd variable means that car cannot turn if not moving
                                                                                //and turning becomes more sensitive as spd increases
        Quaternion rotation = Quaternion.Euler(rotationAngle, 0, 0);
        rb.MoveRotation(rotation);

    }

    public void SetInputVector(Vector3 inputVector)
    {
        turnSpeedInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    void RemoveOrthagonalVelocity() //so in this function we are removing the orthagonal velocity from the car so that it runs much more smoothly
    {
        Vector3 forwardVelocity = transform.forward * Vector3.Dot(rb.velocity, transform.forward);       //first calculate how much fwd velocity the car has

        Vector3 rightVelocity = transform.right * Vector3.Dot(rb.velocity,transform.right);     //finds how much the car is going sideways...

        rb.velocity = forwardVelocity + (rightVelocity * driftFactor);  //takes away some of the sideways velocity based on drift factor - drift factor 0 means no drift

    }


    //public void GetInputs(float forwards, float turn)
    //{
    //    acceleration = forwards;
    //    turnSpeed = turn;   
    //}

    //void Update()
    //{

    //    rb.AddForce(transform.forward *acceleration, ForceMode.Acceleration);
    //    transform.Rotate(Vector3.up * 1* turnSpeed * Time.deltaTime);
    //}

    ///Code monkey tut


    // Update is called once per frame
    //void Update()
    //{
    //rb.AddForce(transform.forward * driveSpeed, ForceMode.Impulse);

    //returns variable for left/right for car turning
    //Vector3 heading = target.position - transform.position;  //
    //directionNumber = AngleDirection(transform.forward, heading, transform.up); //calls fn that returns 1 if it is to the right, -1 if to the left and 0 if directly ahead or behind

    //if (directionNumber == -1)
    //{
    //    Debug.Log("Left");
    //    transform.Rotate(Vector3.up * 1 * turnSpeed * Time.deltaTime);
    //    rb.AddForce(Vector3.left * (driveSpeed / 2), ForceMode.Acceleration);
    //}



    //}

    //float AngleDirection(Vector3 forward, Vector3 targetDirection, Vector3 up) 
    //{
    //    Vector3 perp = Vector3.Cross(forward, targetDirection);
    //    float direction = Vector3.Dot(perp, up);

    //    if (direction < 0f)
    //    {
    //        return -1f;
    //    } else if (direction > 0f)
    //    {
    //        return 1f;
    //    } else
    //    {
    //        return 0f;
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    target = other.transform;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    target = null;
    //}

}

