using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [HideInInspector] public Tower activeTower, selectedTower;
    public static TowerManager instance;
    public Transform indicator;
    public LayerMask whatIsPlacement, whatIsObstacle;
    public GameObject selectedTowerEffect;
    public float topSafePercent = 12f;
    public bool isPlacing;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isPlacing)
        {
            indicator.position = GetGridPosition();
            RaycastHit hit;

            if (Input.mousePosition.y > Screen.height * (1 - (topSafePercent / 100))) //top x area of the screen
            {
                indicator.gameObject.SetActive(false);
            }
            //Boundaries
            //start point + (so it goes beyond the ground), direction (vector3.up), store info in hit, max distance upwards, layermask
            else if (Physics.Raycast(indicator.position + new Vector3(0, -2, 0), Vector3.up, out hit, 10,whatIsObstacle))
            {
                indicator.gameObject.SetActive(false);
            }
            else
            {
                indicator.gameObject.SetActive(true);
                
                UIManager.instance.notEnoughGoldWarningText.SetActive(MoneyManager.instance.currentMoney < activeTower.cost);
                
                if (Input.GetMouseButtonDown(0))
                {
                    if (MoneyManager.instance.SpendMoney(activeTower.cost))
                    {
                        isPlacing = false;
                        Instantiate(activeTower, indicator.position, activeTower.transform.rotation);
                        indicator.gameObject.SetActive(false);
                        UIManager.instance.notEnoughGoldWarningText.SetActive(false);
                    }
                }
            }
        }
    }

    public void StartTowerPlacement(Tower towerToPlace)
    {
        activeTower = towerToPlace;
        isPlacing = true;
        Destroy(indicator.gameObject);
        Tower placeTower = Instantiate(activeTower);
        placeTower.enabled = false;
        placeTower.GetComponent<Collider>().enabled = false;
        indicator = placeTower.transform;
        
        placeTower.rangeModel.SetActive(true);
        placeTower.rangeModel.transform.localScale = new Vector3(placeTower.range, 1, placeTower.range);
    }

    public Vector3 GetGridPosition()
    {
        Vector3 location = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 200, whatIsPlacement))
        {
            location = hit.point;
        }
        
        location.y = 0;
        return location;
    }

    public void MoveTowerSelectionEffect()
    {
        if (selectedTower != null)
        {
            selectedTowerEffect.transform.position = selectedTower.transform.position;
            selectedTowerEffect.SetActive(true);
        }
    }
}