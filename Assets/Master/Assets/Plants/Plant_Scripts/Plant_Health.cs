using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Health : MonoBehaviour, ITargetable, IAttackable
{

    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    #region IAttackable
    public void fn_IAttack(float damageBaseValue)
    {
        if (damageBaseValue <= 0)
            return;

        currentHealth -= damageBaseValue;
        if (currentHealth <= 0)
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
        Destroy(transform.gameObject);
    }
}
