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

        inputVector.x = 0.01f;
        inputVector.y = 1.0f;  

        carMovement.SetInputVector(inputVector);
    }
}
