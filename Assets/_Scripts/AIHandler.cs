using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHandler : MonoBehaviour
{
    private CarMovement carMovement;

    public enum AIMode { followPlayer, followWaypoints };

    [Header("AI settings")]
    public AIMode aiMode;

    Vector3 targetPosition = Vector3.zero;
    Transform targetTransform = null;


    // Start is called before the first frame update
    void Start()
    {
        carMovement = GetComponent<CarMovement>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = Vector2.zero;

        switch (aiMode) 
        {
            case AIMode.followPlayer:
                FollowPlayer();
                break;

        }
    

        carMovement.SetInputVector(inputVector);
    }

    void FollowPlayer()
    {
        if (targetTransform == null)
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform; //if no target transform finds player and sets target to that 
        }

        if (targetTransform != null)
        {
            targetPosition = targetTransform.position;  //makes the target position the target transform (so car will try to go towards the target)
        }
    }

    float TurnTowardsTarget()
    {
        Vector3 vectorToTarget = targetPosition - transform.position;   //gets the angle between the target vector and the transform position
        vectorToTarget.Normalize();     //gives the vector a magnitude of 1 instead of a very large number, this gives direction of target

        float angleToTarget = Vector3.SignedAngle(vectorToTarget, transform.forward, Vector3.up); //finds the angle between the target direction and the car's forward direction

        angleToTarget *= -1;        //inverts the angle, giving the angle the car needs to turn to line up with the target 

        float steerAmount = angleToTarget / 45;     //This means that due to the clamp in next line, any angle over 45 degrees produces the same steer input as 45 
        steerAmount = Mathf.Clamp(steerAmount, -1.0f, 1.0f);
        return steerAmount;
        
    }
}
