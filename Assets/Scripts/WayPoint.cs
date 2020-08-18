using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    const float gridScale = 10f;
    private Vector3 gridPosition;
    // Start is called before the first frame update
    void awake()
    {
        gridPosition = transform.position;
    }
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetGridScale()
    {
        return gridScale;
    }

    public Vector2 getGridPosition()
    {
        return new Vector2(
            Mathf.RoundToInt(transform.position.x / gridScale) * gridScale,
            Mathf.RoundToInt(transform.position.z / gridScale) * gridScale
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
