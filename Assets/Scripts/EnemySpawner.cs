using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Range(1f, 20f)] float enemySpawnRate = 2f;
    [SerializeField] int roundCount = 10;
    [SerializeField] EnemyMovement enemyDefault;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int spawnCount = 0;
        while(spawnCount <= roundCount)
        {
            Instantiate(enemyDefault, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnRate);
            spawnCount++;
        }
    }
}
