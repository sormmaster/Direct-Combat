using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Range(1f, 20f)] float enemySpawnRate = 2f;
    [SerializeField] int roundCount = 10;
    [SerializeField] EnemyMovement enemyDefault;
    [SerializeField] [Tooltip("Suggested to be half the gridsize.")] float suggestedAdjustment = 5f;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int spawnCount = 0;
        while(spawnCount <= roundCount)
        {
            Vector3 enemyStartingPosition = transform.position;
            enemyStartingPosition.Set(enemyStartingPosition.x, suggestedAdjustment, enemyStartingPosition.z);

            var enemy = Instantiate(enemyDefault, enemyStartingPosition, Quaternion.identity);
            enemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(enemySpawnRate);
            spawnCount++;
        }
    }
}
