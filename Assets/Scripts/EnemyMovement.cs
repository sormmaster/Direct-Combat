using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    PathFinder pathfinder;
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
        pathfinder.PerformSearch();
        foreach(WayPoint point in pathfinder.getPath())
        {
            transform.localPosition = point.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
