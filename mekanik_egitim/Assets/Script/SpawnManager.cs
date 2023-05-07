using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerUpObject;
    public GameObject enemy;
    private float SpawnRange=9;
    public int enemyCount;
    public int enemyToSpawn=3;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(enemyToSpawn);
        Instantiate(powerUpObject, randomSpawnPosition(), powerUpObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<enemy>().Length;
        if (enemyCount == 0)
        {
            enemyToSpawn++;
            SpawnEnemy(enemyToSpawn);
            Instantiate(powerUpObject, randomSpawnPosition(), powerUpObject.transform.rotation);


        }
    }
    public void SpawnEnemy(int enemyToSpawn)
    {
        for(int i = 0; i < enemyToSpawn; i++)
        {

            Instantiate(enemy, randomSpawnPosition(), enemy.transform.rotation);
        }
    }
    public Vector3 randomSpawnPosition()
    {
        float spawnRangeX = Random.Range(-SpawnRange, SpawnRange);
        float spawnRangeZ = Random.Range(-SpawnRange, SpawnRange);
        Vector3 spawnPosition = new Vector3(spawnRangeZ, 0, spawnRangeX);
        return spawnPosition;
    }
}
