using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    private int towerCount = 0;
    [SerializeField] Tower towerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreteTowerAtPoint(WayPoint placement)
    {
        if (towerCount < towerLimit)
        {
            Vector3 towerPosition = placement.transform.position;
            towerPosition.Set(towerPosition.x, placement.GetGridScale() / 2, towerPosition.z);
            Instantiate(towerPrefab, towerPosition, Quaternion.identity);
            placement.isPlaceable = false;
            Debug.Log("clicked on " + gameObject.name);
            towerCount++;
        }
    }
}
