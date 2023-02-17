using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController enemyToSpawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Castle _castle;
    [SerializeField] private Path _path;
    public int amountTospawn = 15;
    private float spawnCounter;

    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    void Update()
    {
        if (amountTospawn > 0 && LevelManager.instance.levelActive)
        {
            spawnCounter -= Time.deltaTime;
           
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;
                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(_castle, _path);
                amountTospawn--;
            }
        }
        
    }
    
}
