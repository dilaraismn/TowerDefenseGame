using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenShots = 1f;

    private float shotCounter;
    private Transform targetEnemy;
    private Tower _tower;
    
    void Start()
    {
        _tower = GetComponent<Tower>();
    }

    void Update()
    {
        shotCounter -= Time.deltaTime;
        
        if (shotCounter <= 0 && targetEnemy != null)
        {
            shotCounter = timeBetweenShots;
            firePoint.LookAt(targetEnemy);
            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }

        if (_tower.enemiesInRange.Count > 0)
        {
            float minDistance = _tower.range + 1;
            foreach (EnemyController enemy in _tower.enemiesInRange)
            {
                if (enemy != null)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        targetEnemy = enemy.transform;
                    }
                }
            }
        }
        else
        {
            targetEnemy = null;
        }
    }
}
