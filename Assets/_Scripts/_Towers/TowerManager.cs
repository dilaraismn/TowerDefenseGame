using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;
    public Transform indicator;
    public Tower activeTower;
    public LayerMask whatIsPlacement;
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

            if (Input.GetMouseButtonDown(0))
            {
                isPlacing = false;
                Instantiate(activeTower, indicator.position, activeTower.transform.rotation);
                indicator.gameObject.SetActive(false);
            }
        }
    }

    public void StartTowerPlacement(Tower towerToPlace)
    {
        activeTower = towerToPlace;
        isPlacing = true;
        indicator.gameObject.SetActive(true);
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
}
