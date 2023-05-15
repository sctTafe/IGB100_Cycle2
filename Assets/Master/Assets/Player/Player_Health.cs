using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Health : MonoBehaviour, ITargetable, IAttackable
{
    public UnityEvent<float> _OnPlayerHealthChange;
    public UnityEvent _OnPlayerDeath;

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

        OnPlayerHealthChangeInvoke();

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
        _OnPlayerDeath?.Invoke();
        _respawn.fn_MovePlayerToRespawnPoint();
        _currentHealth = _maxHealth;
        OnPlayerHealthChangeInvoke();
    }

    private void OnPlayerHealthChangeInvoke()
    {
        float pct = Mathf.Clamp01(_currentHealth / _maxHealth);

        _OnPlayerHealthChange?.Invoke(pct);
    }
}
