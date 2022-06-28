using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthSlider healthslider;

    public int maxHealth = 100;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthslider.SetMaxHealth(currentHealth);
    }

    private void Update()
    {
        currentHealth -= Time.deltaTime;
        healthslider.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthslider.SetHealth(currentHealth);
    }

    public void AddHealth(int health)
    {
        currentHealth += health;
        healthslider.SetHealth(currentHealth);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
