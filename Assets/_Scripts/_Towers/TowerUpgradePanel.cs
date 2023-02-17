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
}
