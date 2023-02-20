using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public List<EnemyHealthController> activeEnemies = new List<EnemyHealthController>();
    public bool levelActive;
    public string nextLevel;
    
    private bool levelVictory;
    private Castle[] _castles;

    private EnemyWaveSpawner[] _waveSpawners;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _castles = FindObjectsOfType<Castle>();
        _waveSpawners = FindObjectsOfType<EnemyWaveSpawner>();
        levelActive = true;
    }

    void Update()
    {
        if (levelActive)
        {
            float totalCastleHealth = 0;
            foreach (Castle castle in _castles)
            {
                totalCastleHealth += castle.currentHealth;
            }
            
            //FAIL
            if (totalCastleHealth <= 0)
            {
                levelActive = false;
                levelVictory = false;
                UIManager.instance.towerButtons.SetActive(false);
            }

            bool wavesComplete = true;
            foreach (EnemyWaveSpawner wavespawn in _waveSpawners)
            {
                if (wavespawn.wavesToSpawn.Count > 0)
                {
                    wavesComplete = false;
                }
            }
            //WIN
            if (activeEnemies.Count == 0 && wavesComplete)
            {
                levelActive = false;
                levelVictory = true;
                UIManager.instance.towerButtons.SetActive(false);
            }

            if (!levelActive)
            {
                UIManager.instance.levelFailScreen.SetActive(!levelVictory);
                UIManager.instance.levelCompleteScreen.SetActive(levelVictory);
                
                UIManager.instance.CloseTowerUpgradePanel();
            }
        }
    }
}
