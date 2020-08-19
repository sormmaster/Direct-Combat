using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform enemyToLookAt;
    [SerializeField] float attackRange = 25f;
    private Vector3 defaultAngles;
    private ParticleSystem laser;

    // Start is called before the first frame update
    void Start()
    {
        defaultAngles = gameObject.transform.rotation.eulerAngles;
        laser = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemyToLookAt)
        {
            returnToNuetral();
            return;
        }
        if (Vector3.Distance(enemyToLookAt.transform.position, gameObject.transform.position) < attackRange){
            fireAt();
        } else
        {
            returnToNuetral();
        }
            
    }

    void fireAt()
    {
        gameObject.transform.LookAt(enemyToLookAt);
        var emision = laser.emission;
        emision.enabled = true;
        
    }

    void returnToNuetral()
    {
        gameObject.transform.eulerAngles = new Vector3(defaultAngles.x, gameObject.transform.eulerAngles.y, defaultAngles.z);
        var emision = laser.emission;
        emision.enabled = false;
    }

}
