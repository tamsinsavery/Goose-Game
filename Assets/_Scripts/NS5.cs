using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NS5 : MonoBehaviour
{
    public NS5[] nextWayPointNode;   //variable for the next node in the track

    public float minDistanceToReachNode = 10;  //when the car has travelled this distance, it knows it has reached the next waypoint
}
