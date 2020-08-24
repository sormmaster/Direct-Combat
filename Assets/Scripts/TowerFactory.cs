using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] GameObject parentOfTowers;
    Queue<Tower> towerGroup = new Queue<Tower>();

    [SerializeField] Tower towerPrefab;
    // Start is called before the first frame update

    public void CreteTowerAtPoint(WayPoint placement)
    {
        if (towerGroup.Count >= towerLimit)
        {
            Tower removedTower = towerGroup.Dequeue();
           
            removedTower.baseWaypoint.isPlaceable = true;
            placement.isPlaceable = false;
            removedTower.baseWaypoint = placement;
            Vector3 towerPosition = placement.transform.position;
            towerPosition.Set(towerPosition.x, placement.GetGridScale() / 2, towerPosition.z);
            removedTower.transform.position = towerPosition;
            removedTower.transform.parent = parentOfTowers.transform;
            towerGroup.Enqueue(removedTower);
        } else
        {
            towerGroup.Enqueue(giveTower(placement));
        }
        
    }

   public Tower giveTower(WayPoint placement)
    {
        Vector3 towerPosition = placement.transform.position;
        towerPosition.Set(towerPosition.x, placement.GetGridScale() / 2, towerPosition.z);
        var createdTower = Instantiate(towerPrefab, towerPosition, Quaternion.identity);
        createdTower.transform.parent = parentOfTowers.transform;
        placement.isPlaceable = false;
        createdTower.baseWaypoint = placement;
        return createdTower;
    }
}
