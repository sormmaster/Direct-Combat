using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2, WayPoint> grid = new Dictionary<Vector2, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    bool isRunning = true;
    [SerializeField] WayPoint start, end;
    WayPoint pivot;
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
        StartSearch();
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
                start = waypoints.Last();
            }
            if (!end)
            {
                end = waypoints.First();
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

    public void StartSearch()
    {
        isRunning = true;
        FindShortestPath();
    }

    public void SearchFinished()
    {

    }

    public void FindShortestPath()
    {
        
        queue.Enqueue(start);

        while(queue.Count > 0 && isRunning)
        {
            pivot = queue.Dequeue();
            pivot.isExplored = true;
            if(pivot.Equals(end))
            {
                print("found end");
                isRunning = false;
                return;
            } else
            {
                ExploreNeighbors();
            }
            
        }

    }

    private void ExploreNeighbors()
    {
        foreach (Vector2 direction in directions)
        {
            Vector2 exploredNeighbor = pivot.getGridPosition() + direction;

            if (grid.ContainsKey(exploredNeighbor) && !grid[exploredNeighbor].isExplored && !queue.Contains(grid[exploredNeighbor]))
            {
                QueueNewNeighbors(exploredNeighbor);
            }
        }
    }

    private void QueueNewNeighbors(Vector2 explored)
    {
        WayPoint neighbor = grid[explored];
        neighbor.exploredFrom = pivot;
        queue.Enqueue(neighbor);
    }
}
