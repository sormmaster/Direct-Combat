using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class ControlSnap : MonoBehaviour
{
    // Start is called before the first frame update

    float forcedHeight = 0f;
    float trueScale;
    WayPoint waypoint;

    TextMesh textMesh;
    void Awake()
    {
        waypoint = GetComponent<WayPoint>();
        trueScale = waypoint.GetGridScale();
    }
    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = "TEST";
    }
    void Update()
    {
        updatePosition();
        updateLabel();
        updateScale();
       
    }

    void updatePosition()
    {
        if (!transform.Equals(waypoint.getPosition()))
        {
            waypoint.setPosition( new Vector3(waypoint.getGridPosition().x, forcedHeight, waypoint.getGridPosition().y));
            transform.position = waypoint.getPosition();
        }
    }

    void updateLabel()
    {
        if (textMesh)
        {
            string labelText = waypoint.getGridPosition().x / trueScale + "x" + waypoint.getGridPosition().y / trueScale;
            textMesh.text = labelText;
            gameObject.name = labelText;
        }
    }

    void updateScale()
    {
        if (transform.localScale.x != (trueScale * 0.95f))
        {
            float scaled = trueScale * 0.95f;
            transform.localScale = new Vector3(scaled, scaled, scaled);

        }
    }
}
