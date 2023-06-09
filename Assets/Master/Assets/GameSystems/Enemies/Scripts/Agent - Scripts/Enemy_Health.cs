using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy_Health : MonoBehaviour, IDamageable
{
    public UnityEvent _onTakeDamage;
    public UnityEvent _onDeath;

    public float _maxHealth = 100;
    public float _currentHealth;

    public GameObject DropLoot;

    void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void fn_IDamage(float baseDamageValue)
    {
        if (baseDamageValue <= 0)
            return;

        _currentHealth -= baseDamageValue;
        _onTakeDamage?.Invoke();

        if (_currentHealth <= 0)
        {
            Die();
        }

        Debug.Log("Damage Done: [" + baseDamageValue + "]");
    }

    public void DropSeed()
    {
        Vector3 position = transform.position;
        GameObject Loot = Instantiate(DropLoot, position, Quaternion.identity);

    }

    void Die()
    {
        DropSeed();
        Destroy(transform.gameObject);
        _onDeath?.Invoke();
    }

}
