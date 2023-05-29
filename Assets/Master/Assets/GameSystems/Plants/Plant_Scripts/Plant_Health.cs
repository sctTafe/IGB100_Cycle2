using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Plant_Health : MonoBehaviour, ITargetable, IAttackable
{
    public UnityEvent _OnPlantTakeDamage;
    public UnityEvent _OnPlantDeath;


    public float _maxHealth = 100;
    public float _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    #region IAttackable
    public void fn_IAttack(float damageBaseValue)
    {
        if (damageBaseValue <= 0)
            return;

        _currentHealth -= damageBaseValue;
        _OnPlantTakeDamage?.Invoke();

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    #endregion
    #region ITargetable
    public TargetableType fn_IGetTargetableType()
    {
        return TargetableType.Plant;
    }

    public float? fn_IGetTargetingRangeOverideValue()
    {
        return null;
    }
    #endregion



    void Die()
    {
        _OnPlantDeath?.Invoke();
        Destroy(transform.gameObject);
    }
}
