using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objecttoPan;
    [SerializeField] Transform enemyToLookAt;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        objecttoPan.LookAt(enemyToLookAt);
    }
}
