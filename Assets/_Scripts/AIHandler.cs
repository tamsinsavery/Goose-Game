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

    }
}

