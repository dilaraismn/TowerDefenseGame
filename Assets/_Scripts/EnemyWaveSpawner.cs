using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Castle _castle;
    [SerializeField] private Path _path;

    public List<EnemyWave> wavesToSpawn;
    public float waitForFirstSpawn;
    public bool shouldSpawn = true;
    private float spawnCounter;


    void Start()
    {
        spawnCounter = waitForFirstSpawn;
    }

    void Update()
    {
        if (shouldSpawn)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                if (wavesToSpawn.Count > 0)
                {
                    if (wavesToSpawn[0].enemySpawnOrder.Count > 0)
                    {
                        //spawn the index 0, delete it so the next one becomes the index 0 and continues like that
                        Instantiate(wavesToSpawn[0].enemySpawnOrder[0], spawnPoint.position, spawnPoint.rotation);
                        spawnCounter = wavesToSpawn[0].timeBetweenSpawns;
                        wavesToSpawn[0].enemySpawnOrder.RemoveAt(0);
                        if (wavesToSpawn[0].enemySpawnOrder.Count == 0)
                        {
                            spawnCounter = wavesToSpawn[0].timeToNextWave;
                            wavesToSpawn.RemoveAt(0);
                            if (wavesToSpawn.Count == 0)
                            {
                                shouldSpawn = false;
                            }
                        }
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class EnemyWave
{
    public List<EnemyController> enemySpawnOrder = new List<EnemyController>(0);
    public float timeBetweenSpawns;
    public float timeToNextWave;
}
