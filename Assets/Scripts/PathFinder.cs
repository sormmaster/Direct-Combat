using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2, WayPoint> grid = new Dictionary<Vector2, WayPoint>();
    // Start is called before the first frame update
    void Start()
    {
        loadBlocks();
    }

    private void loadBlocks()
    {
        WayPoint[] waypoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint waypoint in waypoints)
        {
            bool exists = grid.ContainsKey(waypoint.getGridPosition());
            if(!exists)
            {
                grid.Add(waypoint.getGridPosition(), waypoint);
            }
        }
    }
}
