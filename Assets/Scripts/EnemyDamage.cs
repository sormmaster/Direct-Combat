using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;
    
    // Start is called before the first frame update

    private void OnParticleCollision(GameObject other)
    {
        hitParticlesPrefab.Play();
        processHit();
        if(hitPoints < 1)
        {
            killMe();
        }
    }

    void processHit()
    {
        hitPoints = hitPoints - 1;
        gameObject.GetComponentInParent<AudioSource>().PlayOneShot(hitSFX);
    }

    public void killMe()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        gameObject.GetComponentInParent<AudioSource>().PlayOneShot(deathSFX);
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject, vfx.main.duration);
    }
}
