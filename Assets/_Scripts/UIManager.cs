using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject notEnoughGoldWarningText, levelCompleteScreen, levelFailScreen, towerButtons, pauseScreen;
    public TowerUpgradePanel towerUpgradePanel;
    public static UIManager instance;
    public TextMeshProUGUI goldText;
    public string levelSelectScene, mainMenuScene;
    public TMP_Text waveText;
    
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void LevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelSelectScene);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(LevelManager.instance.nextLevel);
    }

    public void OpenTowerUpgradePanel()
    {
        if (LevelManager.instance.levelActive)
        {
            towerUpgradePanel.gameObject.SetActive(true);
            towerUpgradePanel.SetupPanel();
        }
    }
    
    public void CloseTowerUpgradePanel()
    {
        towerUpgradePanel.gameObject.SetActive(false);
       // TowerManager.instance.selectedTower.rangeModel.SetActive(false);
        TowerManager.instance.selectedTower = null;
        TowerManager.instance.selectedTowerEffect.SetActive(false);
        
        notEnoughGoldWarningText.SetActive(false);
    }
    
}
