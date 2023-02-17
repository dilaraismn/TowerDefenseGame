using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public bool levelActive;
    private bool levelVictory;
    public List<EnemyHealthController> activeEnemies = new List<EnemyHealthController>();
    private Castle _castle;
    private SimpleEnemySpawner _enemySpawner;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _castle = FindObjectOfType<Castle>();
        _enemySpawner = FindObjectOfType<SimpleEnemySpawner>();
        levelActive = true;
    }

    void Update()
    {
        if (levelActive)
        {
            //FAIL
            if (_castle.currentHealth <= 0)
            {
                levelActive = false;
                levelVictory = false;
                UIManager.instance.levelFailScreen.SetActive(true);
                UIManager.instance.towerButtons.SetActive(false);
            }

            //WIN
            if (activeEnemies.Count == 0 && _enemySpawner.amountTospawn == 0)
            {
                levelActive = false;
                levelVictory = true;
                UIManager.instance.levelCompleteScreen.SetActive(true);
                UIManager.instance.towerButtons.SetActive(false);
            }
        }
    }
}
