using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ControlSnap : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] [Range(0f, 10f)] float forcedHeight = 0f;
    [SerializeField] [Range(1f, 10f)] float trueScale = 5f;
    Vector3 lastTransform = new Vector3();

    TextMesh textMesh;
    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = "TEST";
    }
    void Update()
    {
        updatePosition();
        updateScale();
       
    }

    void updatePosition()
    {
        if (!transform.Equals(lastTransform))
        {
            Vector3 snapPos;
            snapPos.x = Mathf.RoundToInt(transform.position.x / trueScale) * trueScale;
            snapPos.z = Mathf.RoundToInt(transform.position.z / trueScale) * trueScale;
            snapPos.y = forcedHeight;
            transform.position = snapPos;
            lastTransform = transform.position;
            if(textMesh)
            {
                textMesh.text = snapPos.x + "x" + snapPos.z;
            }
        }
    }

    void updateScale()
    {
        if (transform.localScale.x != trueScale)
        {
            transform.localScale = new Vector3(trueScale, trueScale, trueScale);

        }
    }
}
