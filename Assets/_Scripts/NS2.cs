using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NS2 : MonoBehaviour
{
    public NS2[] nextWayPointNode;   //variable for the next node in the track

    public float minDistanceToReachNode = 10;  //when the car has travelled this distance, it knows it has reached the next waypoint
}
