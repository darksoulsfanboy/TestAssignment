using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private int wave = 1;
    private int enemyCount;
    private float spawnRange = 4f;
    private Vector2 randomPos;

    private void Start()
    {
        EnemyWave(wave);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyMovement>().Length;

        if (enemyCount == 0)
        {
            wave += 1;
            EnemyWave(wave);
        }
    }

    private void EnemyWave(int enemiesCount)
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            Instantiate(enemy, SpawnPosition(), enemy.transform.rotation);
        }
    }

    private Vector2 SpawnPosition()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);

        Vector2 randomPosition = new Vector2(x, z);

        return randomPosition;
    }
}
