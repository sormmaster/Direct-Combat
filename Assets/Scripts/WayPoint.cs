using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    const float gridScale = 10f;

    private Vector3 gridPosition;


    public bool isExplored = false;
    public WayPoint exploredFrom;
    public bool isPlaceable = true;

 

    // Start is called before the first frame update
    void awake()
    {
        gridPosition = transform.position;
    }


    void OnMouseOver()
    {
        // update with enum
        if (Input.GetMouseButtonDown(0))
        {
            placeObject(true);
        } else if (Input.GetMouseButtonDown(1))
        {
            placeObject(false);
        }
    }

    void placeObject(bool tower)
    {
        if (tower)
        {
            //update with switch statement
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().CreteTowerAtPoint(this);
            }
        } else
        {
            if(!isPlaceable)
            {
                FindObjectOfType<WallFactory>().CreateWallAtPoint(this);
            }
          
        }
    }

    public float GetGridScale()
    {
        return gridScale;
    }

    public Vector2 getGridPosition()
    {
        return new Vector2(
            Mathf.RoundToInt(transform.position.x / gridScale),
            Mathf.RoundToInt(transform.position.z / gridScale)
            );
    }

    public void setPosition(Vector3 position)
    {
        gridPosition = position;
    }

    public Vector3 getPosition()
    {
        return gridPosition;
    }

}
