using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Targeting : MonoBehaviour
{
    public Action<Transform> _OnTargetChange;

    public float _targetingRange = 10.0f;
    private Transform _currentTarget;

    private Enemy_TargetingManager _enemyTargetingManager;
    private Transform _newTarget;
    private void Start()
    {
        TryGet_EnemyTargetingManger();
    }

    private void FixedUpdate()
    {
        UpdateTargeting();
    }

    private void UpdateTargeting()
    {

        _newTarget = TryGet_EnemyTargetingManger()?.fn_GetCurrentTargetTransform(this.transform, _targetingRange);

        if (_newTarget != _currentTarget)
        {
            _currentTarget = _newTarget;
            // -- Call OnTargetChange Event --
            _OnTargetChange?.Invoke(_currentTarget);
        }
    }

    private Enemy_TargetingManager TryGet_EnemyTargetingManger()
    {
        if (_enemyTargetingManager != null)
            return _enemyTargetingManager;
        _enemyTargetingManager = Enemy_TargetingManager.Instance;
        return _enemyTargetingManager;
    }

}

