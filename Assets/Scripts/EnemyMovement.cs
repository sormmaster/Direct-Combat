using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    PathFinder pathfinder;
    [SerializeField ]public float heightAdjustment = 5f;
    [SerializeField] public float movementPause = 0.5f;
    [SerializeField] ParticleSystem goalParticle;
    void Start()
    {
         pathfinder = FindObjectOfType<PathFinder>();
         StartCoroutine(TravelOverPoints());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator TravelOverPoints()
    {        
        foreach(WayPoint point in pathfinder.getPath())
        {
           
            Vector3 enemyNewPosition = point.transform.position;
            enemyNewPosition.Set(enemyNewPosition.x, point.GetGridScale()/2, enemyNewPosition.z);
            transform.localPosition = enemyNewPosition;
            yield return new WaitForSeconds(movementPause);
        }

        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject, vfx.main.duration);
    }
}
