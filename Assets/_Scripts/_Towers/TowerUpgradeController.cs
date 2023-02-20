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
    [TextArea]public string fireRateText;

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

    public void UpgradeFireRate()
    {
        _tower.fireRate = fireRateUpgrades[currenFireRateUpgrade].amount;
        currenFireRateUpgrade++;
        if (currenFireRateUpgrade >= fireRateUpgrades.Length)
        {
            hasFireRateUpgrade = false;
        }
    }
}

[System.Serializable]
public class UpgradeStage
{
    public float amount;
    public int cost;
}