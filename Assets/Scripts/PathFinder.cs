using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2, WayPoint> grid = new Dictionary<Vector2, WayPoint>();
    [SerializeField] WayPoint start, end;
    Vector2[] directions =
    {
        Vector2.up,
        Vector2.right,
        Vector2.down,
        Vector2.left    
    };

    // Start is called before the first frame update
    void Start()
    {
        loadBlocks();
        setEndAndBeginning();
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        foreach(Vector2 direction in directions)
        {
            Vector2 exploredNeighbor = start.getGridPosition() + direction;

            if (grid.ContainsKey(exploredNeighbor))
            {
               grid[exploredNeighbor].SetTopColor(Color.white);
            }
        }
    }

    private void loadBlocks()
    {
        WayPoint[] waypoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint waypoint in waypoints)
        {
            bool exists = grid.ContainsKey(waypoint.getGridPosition());
            if(!exists)
            {
                waypoint.SetTopColor(Color.gray);
                grid.Add(waypoint.getGridPosition(), waypoint);
            } else
            {
                waypoint.SetTopColor(Color.clear);
            }
        }
        if(waypoints.Length == 0)
        {
            return;
        }
        try
        {
            if (!start)
            {
                start = waypoints.First();
            }
            if (!end)
            {
                end = waypoints.Last();
            }
        } catch (System.Exception ignore)
        {

        }
       
    }

    private void setEndAndBeginning()
    {
        try
        {
            start.SetTopColor(Color.cyan);
            end.SetTopColor(Color.blue);
        } catch (System.Exception ignore)
        {

        }

    }
}
