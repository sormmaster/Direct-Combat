using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ControlSnap : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] [Range(0f, 10f)] float forcedHeight = 0f;
    [SerializeField] [Range(1f, 10f)] float trueScale = 5f;
    void Update()
    {
        updatePosition();

        updateScale();
       
    }

    void updatePosition()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / trueScale) * trueScale;
        snapPos.z = Mathf.RoundToInt(transform.position.z / trueScale) * trueScale;
        snapPos.y = forcedHeight;
        transform.position = snapPos;
    }

    void updateScale()
    {
        if (transform.localScale.x != trueScale)
        {
            transform.localScale = new Vector3(trueScale, trueScale, trueScale);

        }
    }
}
