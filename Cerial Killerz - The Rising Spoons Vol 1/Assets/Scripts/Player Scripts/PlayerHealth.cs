using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthSlider healthslider;

    public int maxHealth = 100;
    public float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
        if (healthslider != null)
        {
            healthslider.SetMaxHealth(currentHealth);
        }
    }

    public void Update()
    {
        currentHealth -= Time.deltaTime;
        if (healthslider != null)
        {
            healthslider.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthslider != null)
        {
            healthslider.SetHealth(currentHealth);
        }
    }

    public void AddHealth(int health)
    {
        currentHealth += health;
        if (healthslider != null)
        {
            healthslider.SetHealth(currentHealth);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
