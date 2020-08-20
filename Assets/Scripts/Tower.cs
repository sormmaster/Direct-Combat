using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Tower : MonoBehaviour
{
    
    [SerializeField] float attackRange = 25f;
    private Vector3 defaultAngles;
    private ParticleSystem laser;

    Transform enemyToLookAt;
    // Start is called before the first frame update
    void Start()
    {
        defaultAngles = gameObject.transform.rotation.eulerAngles;
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
        var distanceOne = Vector3.Distance(transform.position, one.position);
        var distanceTwo = Vector3.Distance(transform.position, two.position);

        return (distanceOne < distanceTwo);
    }

}
