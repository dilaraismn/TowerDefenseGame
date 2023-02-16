using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] private float totalHealth = 100;
    [SerializeField] private Slider healthSlider;
    public float currentHealth;
    
    void Start()
    {
        currentHealth = totalHealth;
        healthSlider.maxValue = totalHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }

        healthSlider.value = currentHealth;
    }
}
