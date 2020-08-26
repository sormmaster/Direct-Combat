using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Range(1f, 20f)] float enemySpawnRate = 2f;
    [SerializeField] int roundCount = 10;
    [SerializeField] EnemyMovement enemyDefault;
    [SerializeField] [Tooltip("Suggested to be half the gridsize.")] float suggestedAdjustment = 5f;
    [SerializeField] Text spawnText;
    int score = 0;
    void Start()
    {
        updateText();
        StartCoroutine(SpawnEnemy(10, 0.5f, 2f));
        new WaitForSeconds(1f);
        StartCoroutine(SpawnEnemy(5, 0.25f, 10f));
    }

    IEnumerator SpawnEnemy(int waveCount, float speed, float spread)
    {
        
        int spawnCount = 0;
        while(spawnCount < waveCount)
        {
            Vector3 enemyStartingPosition = transform.position;
            enemyStartingPosition.Set(enemyStartingPosition.x, suggestedAdjustment, enemyStartingPosition.z);

            var enemy = Instantiate(enemyDefault, enemyStartingPosition, Quaternion.identity);
            enemy.movementPause = speed;
            enemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(spread);
            spawnCount++;
            score++;
            updateText();
        }
    }

    private void updateText()
    {
        spawnText.text = score.ToString();
    }
}
