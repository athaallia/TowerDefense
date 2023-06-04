using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypointTransform;



    private void Awake()
    {
        waypointTransform = new Transform[transform.childCount];
        for (int i = 0; i < waypointTransform.Length; i++)
        {
            waypointTransform[i] = transform.GetChild(i);
        }
    }
}
