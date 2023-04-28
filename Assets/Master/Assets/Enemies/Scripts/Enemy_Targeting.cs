using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Targeting : MonoBehaviour
{
    public float _targetingRange = 10.0f;
    private Transform _currentTarget;

    private Enemy_TargetingManager _enemyTargetingManager;
    private Enemy_Movement_AINav _enemy_Movement_AINav;
    private Transform _newTarget;
    private void Start()
    {
        TryGet_EnemyMovementAINav();
        TryGet_EnemyTargetingManger();
    }

    private void FixedUpdate()
    {
        UpdateTargeting();
    }

    private void UpdateTargeting()
    {

        _newTarget = TryGet_EnemyTargetingManger().fn_GetCurrentTargetTransform(this.transform, _targetingRange);

        if (_newTarget != _currentTarget)
        {
            _currentTarget = _newTarget;
            TryGet_EnemyMovementAINav().fn_SetTargetTransfrom(_newTarget);
        }
    }


    private Enemy_TargetingManager TryGet_EnemyTargetingManger()
    {
        if (_enemyTargetingManager != null)
            return _enemyTargetingManager;
        _enemyTargetingManager = Enemy_TargetingManager.Instance;
        return _enemyTargetingManager;
    }

    private Enemy_Movement_AINav TryGet_EnemyMovementAINav()
    {
        if (_enemy_Movement_AINav != null)
            return _enemy_Movement_AINav;
        _enemy_Movement_AINav = this.GetComponent<Enemy_Movement_AINav>();
        return _enemy_Movement_AINav;
    }

}

