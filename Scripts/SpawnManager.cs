using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform playerPos;
    public GameObject[] enemyPrefabs;
    public int startingWaveSize = 1;
    public float xSpawnRange = 10f;
    public float ySpawnRange = 8f;

    private float spawnInterval = 0.5f;
    private float waveInterval = 2f;

    private int currentWaveSize;
    private bool isSpawningNextWave = false;

    void Start()
    {
        currentWaveSize = startingWaveSize;
        StartCoroutine(WaveSpawner(currentWaveSize));
    }

    void Update()
    {
        if (!isSpawningNextWave && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StartCoroutine(SpawnNextWave());
        }
    }

    IEnumerator WaveSpawner(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(
            Random.Range(playerPos.position.x - xSpawnRange, playerPos.position.x + xSpawnRange),
            Random.Range(playerPos.position.y - ySpawnRange, playerPos.position.y + ySpawnRange),
            -2
        );

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }

    IEnumerator SpawnNextWave()
    {
        isSpawningNextWave = true; 

        yield return new WaitForSeconds(waveInterval); 

        currentWaveSize++; 

        yield return StartCoroutine(WaveSpawner(currentWaveSize));

        isSpawningNextWave = false; 
    }
}