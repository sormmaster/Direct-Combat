using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("got hit");
        processHit();
        if(hitPoints < 1)
        {
            destroyEnemy();
        }
    }

    private void destroyEnemy()
    {
        Destroy(gameObject);
    }

    void processHit()
    {
        hitPoints = hitPoints - 1;
    }
}
