using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    //public int animalPrefabIndex;
    public float xPositionI = 200.0f;
    public float xPosition = 700.0f;
    public float yPositionI = 50.0f;
    public float yPosition = 200.0f;
    public float zPositionI = 200.0f;
    public float zPosition = 700.0f;

    private int waveCount = 0;
    private int enemyCount;
    private int turretCount;
    private int seekerCount;
    private int spreadCount;
    public int waveLimit = 20;
    private int spawnNumber = 6;

    void Start()
    {
        //InvokeRepeating("SpawnRandomEnemy", 3.0f, 1.0f);
        SpawnWave(6);
    }

    // Update is called once per frame
    private void Update()
    {
        turretCount = FindObjectsOfType<TurretEnemy>().Length;
        seekerCount = FindObjectsOfType<SeekerEnemy>().Length;
        spreadCount = FindObjectsOfType<EnemySpread>().Length;
        if (turretCount == 0 && seekerCount == 0 && spreadCount == 0 && waveCount <= waveLimit)
        {
            SpawnWave(spawnNumber);
            
            spawnNumber = spawnNumber + 4;
            
        }

        if(waveCount >= waveLimit)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    void SpawnWave(int enemyNum)
    {
        for (int i = 0; i < enemyNum; i++)
        {
            SpawnRandomEnemy();
            waveCount = waveCount + 1;
            Debug.Log(waveCount);
        }

    }
    void SpawnRandomEnemy()
    {
        
        int enemyPrefabIndex = Random.Range(0, enemyPrefabs.Length);
        
        Instantiate(enemyPrefabs[enemyPrefabIndex], GenerateSpawnPosition(),
            enemyPrefabs[enemyPrefabIndex].transform.rotation);
    }

    Vector3 GenerateSpawnPosition()
    {
        float randXPos = Random.Range(xPositionI, xPosition);
        float randYPos = Random.Range(yPositionI, yPosition);
        float randZPos = Random.Range(zPositionI, zPosition);
        Vector3 spawnpos = new Vector3(randXPos, randYPos, randZPos);

        return spawnpos;
    }
}
