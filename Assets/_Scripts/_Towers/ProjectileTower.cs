using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    [SerializeField] private GameObject projectile, shotEffect;
    [SerializeField] private Transform firePoint, launcherModel;
    
    private float shotCounter;
    private Transform targetEnemy;
    private Tower _tower;
    
    void Start()
    {
        _tower = GetComponent<Tower>();
    }

    void Update()
    {
       CannonModelLookAtEnemy();
       SpawnCannon();
       SetEnemyTarget();
    }
    
    private void SpawnCannon()
    {
        shotCounter -= Time.deltaTime;
        
        if (shotCounter <= 0 && targetEnemy != null)
        {
            shotCounter = _tower.fireRate;
            firePoint.LookAt(targetEnemy);
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            Instantiate(shotEffect, firePoint.position, firePoint.rotation);
        }
    }

    private void SetEnemyTarget()
    {
        if (_tower.isEnemiesUpdated)
        {
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
    
    private void CannonModelLookAtEnemy()
    {
        if (targetEnemy != null)
        {
            launcherModel.rotation = Quaternion.Slerp(launcherModel.rotation, Quaternion.LookRotation(targetEnemy.position - transform.position), 5f * Time.deltaTime);
            launcherModel.rotation = Quaternion.Euler(0, launcherModel.rotation.eulerAngles.y, 0f);
        }
    }
}
