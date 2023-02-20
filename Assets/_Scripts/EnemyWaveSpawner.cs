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
    
    public float waveDisplayTime;
    private float waveDisplayCounter;
    private int waveCounter;

    void Start()
    {
        spawnCounter = waitForFirstSpawn;
        waveCounter = 1;
    }

    void Update()
    {
        if (shouldSpawn)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                if (wavesToSpawn[0].shouldDisplayWave)
                {
                    wavesToSpawn[0].shouldDisplayWave = false;
                    UIManager.instance.waveText.gameObject.SetActive(true);
                    UIManager.instance.waveText.text = "Wave " + waveCounter;
                    waveDisplayCounter = waveDisplayTime;
                }
                
                if (wavesToSpawn.Count > 0)
                {
                    if (wavesToSpawn[0].enemySpawnOrder.Count > 0)
                    {
                        //spawn the index 0, delete it so the next one becomes the index 0 and continues like that
                        Instantiate(wavesToSpawn[0].enemySpawnOrder[0], spawnPoint.position, spawnPoint.rotation).Setup(_castle, _path);
                        spawnCounter = wavesToSpawn[0].timeBetweenSpawns;
                        wavesToSpawn[0].enemySpawnOrder.RemoveAt(0);
                        if (wavesToSpawn[0].enemySpawnOrder.Count == 0)
                        {
                            spawnCounter = wavesToSpawn[0].timeToNextWave;
                            wavesToSpawn.RemoveAt(0);
                            waveCounter++;
                            
                            if (wavesToSpawn.Count == 0)
                            {
                                shouldSpawn = false;
                            }
                        }
                    }
                }
            }
        }

        if (waveDisplayCounter > 0)
        {
            waveDisplayCounter -= Time.deltaTime;
            if (waveDisplayCounter <= 0)
            {
                UIManager.instance.waveText.gameObject.SetActive(false);
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
    [HideInInspector]public bool shouldDisplayWave = true;
}
