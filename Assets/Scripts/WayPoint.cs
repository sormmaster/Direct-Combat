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

    public void SetTopColor(Color color)
    {
       var top = transform.Find("Top");
        MeshRenderer topMesh = top.GetComponent<MeshRenderer>();
        topMesh.material.color = color;
    }
}
