using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private float checkTime = .5f;
    [HideInInspector] public bool isEnemiesUpdated;
    [HideInInspector] public TowerUpgradeController upgrader;

    public List<EnemyController> enemiesInRange = new List<EnemyController>();
    private Collider[] collidersInRange;
    private float checkCounter;
    public GameObject rangeModel;
    public float range = 3;
    public float fireRate;
    public int cost = 100;
    
    void Start()
    {
        checkCounter = checkTime;
        upgrader = GetComponent<TowerUpgradeController>();
    }

    void Update()
    {
        isEnemiesUpdated = false;
        checkCounter -= Time.deltaTime;
        
        if (checkCounter <= 0)
        {
            checkCounter = checkTime;
            collidersInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);
        
            //can be expensive in terms of data usage so we can check and do in time range
            enemiesInRange.Clear();
            foreach (Collider col in collidersInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }

            isEnemiesUpdated = true;
        }

        if (TowerManager.instance.selectedTower == this)
        {
            rangeModel.SetActive(true);
            rangeModel.transform.localScale = new Vector3(range, 1, range);
        }
    }

    private void OnMouseDown()
    {
        if (!LevelManager.instance.levelActive) return;
        
        if (TowerManager.instance.selectedTower != null)
        {
            TowerManager.instance.selectedTower.rangeModel.SetActive(false);
        }
        TowerManager.instance.selectedTower = this;
        UIManager.instance.OpenTowerUpgradePanel();
        TowerManager.instance.MoveTowerSelectionEffect();
    }
}
