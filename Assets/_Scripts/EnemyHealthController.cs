using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth;
    public Slider healthBar;

    private void Start()
    {
        healthBar.maxValue = totalHealth;
        healthBar.value = totalHealth;
    }

    private void Update()
    {
        healthBar.transform.rotation = Camera.main.transform.rotation;
    }

    public void TakeDamage(float damageAmount)
    {
        totalHealth -= damageAmount;
        
        if (totalHealth <= 0)
        {
            Destroy(gameObject);
        }

        healthBar.value = totalHealth;
        healthBar.gameObject.SetActive(true);
    }
}