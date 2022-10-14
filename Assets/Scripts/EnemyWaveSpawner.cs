using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 3.0f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        float randXPos = Random.Range(xPositionI, xPosition);
        float randYPos = Random.Range(yPositionI, yPosition);
        float randZPos = Random.Range(zPositionI, zPosition);
        int enemyPrefabIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 randPos = new Vector3(randXPos, randYPos, randZPos);
        Instantiate(enemyPrefabs[enemyPrefabIndex], randPos,
            enemyPrefabs[enemyPrefabIndex].transform.rotation);
    }
}
