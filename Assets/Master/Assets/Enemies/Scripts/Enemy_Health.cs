using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour, IDamageable
{
    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float baseDamageValue)
    {
        if (baseDamageValue <= 0)
            return;

        currentHealth -= baseDamageValue;
        if (currentHealth <= 0)
        {
            Die();
        }

        Debug.Log("Damage Done: [" + baseDamageValue + "]");
    }

    void Die()
    {
        Destroy(transform.gameObject);
    }

}
