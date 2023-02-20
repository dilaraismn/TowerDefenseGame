using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Castle _castle;
    [SerializeField] private Path _path;

    public EnemyController[] enemiesToSpawn;
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
                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawnPoint.position, spawnPoint.rotation).Setup(_castle, _path);
                amountTospawn--;
            }
        }
        
    }
    
}
