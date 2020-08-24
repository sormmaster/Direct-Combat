using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 2;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    // Start is called before the first frame update

    private void OnParticleCollision(GameObject other)
    {
        hitParticlesPrefab.Play();
        processHit();
        if(hitPoints < 1)
        {
            var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            vfx.Play();
            Destroy(vfx.gameObject,vfx.main.duration);
            Destroy(gameObject, vfx.main.duration);
        }
    }


    void processHit()
    {
        hitPoints = hitPoints - 1;
    }
}
