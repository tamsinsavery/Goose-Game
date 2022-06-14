using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIHandler : MonoBehaviour
{
    private CarMovement carMovement;

    public enum AIMode { followPlayer, followWaypoints };

    [Header("AI settings")]
    public AIMode aiMode;

    Vector3 targetPosition = Vector3.zero;
    Transform targetTransform = null;

    NodeSystem currentnode = null;
    NodeSystem[] allNodes;

    // Start is called before the first frame update
    void Awake()
    {
        carMovement = GetComponent<CarMovement>();
        allNodes = FindObjectsOfType<NodeSystem>();
        aiMode = AIMode.followWaypoints;
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
            case AIMode.followWaypoints:
                FollowWayPoints();
                break;
        }

        inputVector.x = TurnTowardsTarget();
        inputVector.y = ApplyThrottleOrBrake(inputVector.x);
    

        carMovement.SetInputVector(inputVector);
    }

    float ApplyThrottleOrBrake(float inputx)
    {
        return 0.65f - Mathf.Abs(inputx)*20.0f;
        //this uses the absolute value of input (so acceleration is always positive) and divides it by 2, so max acceleration is 0.5
        //subtracts this value from 0.55 so there is always some acceleration 
    }

    void FollowWayPoints()
    {
        if (currentnode == null)
        {
            currentnode = FindClosestNode();
        }

        if (currentnode != null)
        {
            targetPosition = currentnode.transform.position;//if there is a waypoint, set the target position to it

            float distanceToNode = (targetPosition - transform.position).magnitude; //check how close car is to the target 
            
            if (distanceToNode <= currentnode.minDistanceToReachNode)
            {
                currentnode = currentnode.nextWayPointNode[Random.Range(0, currentnode.nextWayPointNode.Length)]; //picks a next node at random from all waypoints connected to current waypoint

            }
        }
    }

    NodeSystem FindClosestNode()
    {
        return allNodes
            .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))  //so, checks distance between current position and the node in the array
                                                                                    //then orders the nodes by the distance from the current position
            .FirstOrDefault();
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

        float angleToTarget = Vector3.Angle(vectorToTarget, transform.forward); //finds the angle between the target direction and the car's forward direction

        angleToTarget *= -1;        //inverts the angle, giving the angle the car needs to turn to line up with the target 

        float steerAmount = angleToTarget/45;     //This means that due to the clamp in next line, any angle over 45 degrees produces the same steer input as 45 
        steerAmount = Mathf.Clamp(steerAmount, -1.0f, 1.0f);
        steerAmount = steerAmount / 50;
        return steerAmount;
        
    }
}
