using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFactory : MonoBehaviour
{
    int wallLimit = 3;
    [SerializeField] GameObject parentOfWalls;
    int currentWalls = 0;

    [SerializeField] Wall wallPrefab;
    // Start is called before the first frame update

    public void CreateWallAtPoint(WayPoint placement)
    {
        if(currentWalls >= wallLimit)
        {
            return;
        } else
        {
            Vector3 towerPosition = placement.transform.position;
            towerPosition.Set(towerPosition.x, placement.GetGridScale() / 2, towerPosition.z);
            Wall createdWall = Instantiate(wallPrefab, towerPosition, Quaternion.identity);
            createdWall.transform.parent = parentOfWalls.transform;
            placement.isPlaceable = false;
            createdWall.baseWaypoint = placement;
            currentWalls++;
        }
        
    }

    public void resetLimit()
    {
        currentWalls = 0;
    }


}

