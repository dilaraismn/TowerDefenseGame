using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float totalHealth;

    public void TakeDamage(float damageAmount)
    {
        totalHealth -= damageAmount;
        
        if (totalHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
