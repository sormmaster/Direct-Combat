using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TravelOverPoints());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator TravelOverPoints()
    {
        foreach(WayPoint point in path)
        {
            transform.localPosition = point.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
