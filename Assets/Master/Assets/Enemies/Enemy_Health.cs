using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(int damageValue)
    {
        if (damageValue <= 0)
            return;

        currentHealth -= damageValue;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(transform.parent.gameObject);
    }


}
