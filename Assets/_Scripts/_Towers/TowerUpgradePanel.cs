using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUpgradePanel : MonoBehaviour
{
    public GameObject rangeButton, fireRateButton;
    public TMP_Text rangeText, fireRateText;
    
    public void SetupPanel()
    {
        if (TowerManager.instance.selectedTower.upgrader.hasRangeUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            rangeText.text = "Upgrade\nRange\n(" + upgrader.rangeUpgrades[upgrader.currentRangeUpgrade].cost + "G)";
            rangeButton.SetActive(true);
        }
        else
        {
            rangeButton.SetActive(false);
        }

        if (TowerManager.instance.selectedTower.upgrader.hasFireRateUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            fireRateText.text = upgrader.fireRateText + "(" + upgrader.fireRateUpgrades[upgrader.currenFireRateUpgrade].cost + "G)";
            fireRateButton.SetActive(true);
        }
        else
        {
            fireRateButton.SetActive(false);
        }
    }
    
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
                SetupPanel();
                UIManager.instance.notEnoughGoldWarningText.SetActive(false);
            }
            else
            {
                UIManager.instance.notEnoughGoldWarningText.SetActive(true);
            }
        }
    }

    public void UpgradeFireRate()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasFireRateUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.fireRateUpgrades[upgrader.currenFireRateUpgrade].cost))
            {
                upgrader.UpgradeFireRate();
                SetupPanel();
                UIManager.instance.notEnoughGoldWarningText.SetActive(false);
            }
            else
            {
                UIManager.instance.notEnoughGoldWarningText.SetActive(true);
            }
        }
    }
}
