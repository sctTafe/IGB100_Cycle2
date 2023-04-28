using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour, ITargetable, IAttackable
{
    public float _maxHealth = 200;
    public float _currentHealth;
    public Player_Respawn _respawn;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    #region IAttackable
    public void fn_IAttack(float damageBaseValue)
    {
        if (damageBaseValue <= 0)
            return;

        _currentHealth -= damageBaseValue;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    #endregion
    #region ITargetable
    public TargetableType fn_IGetTargetableType()
    {
        return (TargetableType.Player);
    }
    public float? fn_IGetTargetingRangeOverideValue()
    {
        return null;
    }
    #endregion

    void Die()
    {
        _respawn.fn_MovePlayerToRespawnPoint();
        _currentHealth = _maxHealth;
    }
}
