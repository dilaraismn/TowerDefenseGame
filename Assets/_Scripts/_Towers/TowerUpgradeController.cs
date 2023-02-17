using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    private Tower _tower;
    
    public UpgradeStage[] rangeUpgrades;
    public int currentRangeUpgrade;
    public bool hasRangeUpgrade = true;
    
    public UpgradeStage[] fireRateUpgrades;
    public int currenFireRateUpgrade;
    public bool hasFireRateUpgrade = true;

    void Start()
    {
        _tower = GetComponent<Tower>();
    }

    void Update()
    {
        
    }
}

[System.Serializable]
public class UpgradeStage
{
    public float amount;
    public float cost;
}