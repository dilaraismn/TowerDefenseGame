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

    public void UpgradeRange()
    {
        _tower.range = rangeUpgrades[currentRangeUpgrade].amount;
        currentRangeUpgrade++;
        if (currentRangeUpgrade >= rangeUpgrades.Length)
        {
            hasRangeUpgrade = false;
        }
        
    }
}

[System.Serializable]
public class UpgradeStage
{
    public float amount;
    public int cost;
}