using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        currentHealth -= Time.deltaTime / 4;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void AddHealth(int health)
    {
        currentHealth += health;
    }
}
