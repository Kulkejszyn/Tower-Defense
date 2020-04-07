using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {
    public static Transform[] waypoints;

    private void Awake() {
        waypoints = GetComponentsInChildren<Transform>();
    }

    internal static Transform getEndPoint() {
        foreach (var point in waypoints)
            if (point.tag == "End")
                return point;
        Debug.LogError("No end point");
        return null;
    }

    internal static Transform getSpawnPoint() {
        return waypoints[1];
    }
}