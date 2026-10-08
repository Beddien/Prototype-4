using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    private int enemiesPerWave = 1;
    public int enemyCount;
    public GameObject powerupPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        SpawnEnemyWave(enemiesPerWave);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0) {
            enemiesPerWave++;
            SpawnPowerup();
            SpawnEnemyWave(enemiesPerWave);
        }
    }

    private Vector3 GenerateSpawnPosition () {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosY);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn) {
        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), 
            enemyPrefab.transform.rotation);

        }
    }

    void SpawnPowerup() {
        Instantiate(powerupPrefab, 
        GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
}
