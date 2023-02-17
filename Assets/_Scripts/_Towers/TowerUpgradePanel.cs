using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradePanel : MonoBehaviour
{
    public void RemoveTower()
    {
        MoneyManager.instance.SpendMoney(-50);
        Destroy(TowerManager.instance.selectedTower.gameObject);
        UIManager.instance.CloseTowerUpgradePanel();
    }

    public void UpgradeRange()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
        
        if (upgrader.hasRangeUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.rangeUpgrades[upgrader.currentRangeUpgrade].cost))
            {
                upgrader.UpgradeRange();
            }
        }
    }
}
