using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace ScottBarley.IGB100.V1
{
    public class Golem_Health : MonoBehaviour, ITargetable, IAttackable
    {
        public UnityEvent<float> _OnGolemHealthChange;
        public UnityEvent _OnGolemDeath;

        public float _maxHealth = 1000;
        public float _currentHealth;

        private void Start()
        {
            fn_SetFullHealth();
        }

        #region IAttackable
        public void fn_IAttack(float damageBaseValue)
        {
            if (damageBaseValue <= 0)
                return;

            _currentHealth -= damageBaseValue;

            float pct = _currentHealth / _maxHealth;
            _OnGolemHealthChange?.Invoke(pct);

            if (_currentHealth <= 0)
            {
                EndGame();
            }
        }
        #endregion
        #region ITargetable
        public TargetableType fn_IGetTargetableType()
        {
            return (TargetableType.GolemHeart);
        }
        public float? fn_IGetTargetingRangeOverideValue()
        {
            return null;
        }
        #endregion

        private void EndGame()
        {
            _OnGolemDeath?.Invoke();
        }

        public void fn_SetFullHealth()
        {
            _currentHealth = _maxHealth;
        }
    }
}