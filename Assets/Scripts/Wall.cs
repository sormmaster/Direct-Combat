using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public WayPoint baseWaypoint;
    private int hitPoints = 2;

    private void OnTriggerEnter(Collider other)
    {
        GameObject check = other.gameObject;
        
        if (check.name.Contains("Enemy"))
        {
            EnemyDamage dmg = check.transform.parent.gameObject.GetComponent<EnemyDamage>();
            dmg.killMe();
            
        }
        hitPoints--;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
