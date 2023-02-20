using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] private float totalHealth = 100;
    [SerializeField] private Slider healthSlider;
    [HideInInspector]public float currentHealth;
    public Transform[] attackPoints;

    void Start()
    {
        currentHealth = totalHealth;
        healthSlider.maxValue = totalHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
            AudioManager.instance.PlaySFX(3);
        }
        else
        {
            AudioManager.instance.PlaySFX(4);
        }

        healthSlider.value = currentHealth;
    }
}
