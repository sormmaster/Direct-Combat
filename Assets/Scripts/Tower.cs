using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Tower : MonoBehaviour
{
    
    [SerializeField] float attackRange = 25f;
    [SerializeField] GameObject towerHead;
    private Vector3 defaultAngles;
    private ParticleSystem laser;

    public WayPoint baseWaypoint;

    Transform enemyToLookAt;
    // Start is called before the first frame update
    void Start()
    {
        defaultAngles = towerHead.transform.rotation.eulerAngles;
        laser = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if(!enemyToLookAt)
        {
            returnToNuetral();
            return;
        }
        if (Vector3.Distance(enemyToLookAt.transform.position, towerHead.transform.position) < attackRange){
            fireAt();
        } else
        {
            returnToNuetral();
        }
            
    }

    void fireAt()
    {
        towerHead.transform.LookAt(enemyToLookAt);
        var emision = laser.emission;
        emision.enabled = true;
        
    }

    void returnToNuetral()
    {
        towerHead.transform.eulerAngles = new Vector3(defaultAngles.x, towerHead.transform.eulerAngles.y, defaultAngles.z);
        var emision = laser.emission;
        emision.enabled = false;
    }

    void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<EnemyDamage>();
        if(enemies.Length == 0) { return; }

        Transform closestEnemy = enemies[0].transform;
        foreach (EnemyDamage enemy in enemies) {
            if(!isCloser(closestEnemy, enemy.transform))
            {
                closestEnemy = enemy.transform;
            }
        }
        enemyToLookAt = closestEnemy;
    }

    bool isCloser(Transform one, Transform two)
    {
        var distanceOne = Vector3.Distance(towerHead.transform.position, one.position);
        var distanceTwo = Vector3.Distance(towerHead.transform.position, two.position);

        return (distanceOne < distanceTwo);
    }

}
