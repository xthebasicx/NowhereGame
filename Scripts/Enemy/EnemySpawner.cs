using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 20;
    public float spawnInterval = 30f;

    private List<GameObject> enemies = new List<GameObject>();
    private float spawnTimer;
    private bool initialSpawnDone = false;

    void Start()
    {
        SpawnAllEnemies();
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }

        if (initialSpawnDone && enemies.Count < maxEnemies)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f)
            {
                SpawnEnemy();
                spawnTimer = spawnInterval;
            }
        }
    }

    void SpawnAllEnemies()
    {
        while (enemies.Count < maxEnemies)
        {
            SpawnEnemy();
        }
        initialSpawnDone = true;
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemies.Add(enemy);
    }
}
