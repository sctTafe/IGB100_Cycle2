using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_Targeting))]
public class Enemy_Attack : MonoBehaviour
{
    public float _attackRange = 5f;
    public float _attackRate = 1f;
    public float _attackDamage = 10f;

    private Transform _TargetTransfrom;
    private float nextAttackTime = 0f;
    private IAttackable _iAttackable;
    private Enemy_Targeting _enemyTargeting;


    private void Start()
    {
        if (TryGet_Enemy_Targeting() != null)
            _enemyTargeting._OnTargetChange += Handle_OnTargetChange;
    }
    private void Update()
    {
        if (_TargetTransfrom == null)
            return;

        float distanceToTarget = Vector3.Distance(transform.position, _TargetTransfrom.position);

        if (distanceToTarget <= _attackRange && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / _attackRate;
        }
    }
    private void OnDestroy()
    {
        _enemyTargeting._OnTargetChange -= Handle_OnTargetChange;
    }

    public void fn_SetTarget(Transform targetTrans)
    {
        _TargetTransfrom = targetTrans;

        if (_TargetTransfrom == null)
            _iAttackable = _TargetTransfrom.GetComponent<IAttackable>();
        else
            _iAttackable = null;
    }


    private void Handle_OnTargetChange(Transform targetTrans)
    {
        _TargetTransfrom = targetTrans;

        if (_TargetTransfrom != null)
            _iAttackable = _TargetTransfrom.GetComponent<IAttackable>();
        else
            _iAttackable = null;
    }

    private void Attack()
    {
        //TryGet_IAttackable();
        if (_iAttackable == null)
            return;
        _iAttackable.fn_IAttack(_attackDamage);
    }

    private Enemy_Targeting TryGet_Enemy_Targeting()
    {
        if (_enemyTargeting != null)
            return _enemyTargeting;
        _enemyTargeting = this.GetComponent<Enemy_Targeting>();
        return _enemyTargeting;
    }

    private IAttackable TryGet_IAttackable()
    {
        if (_iAttackable != null)
            return _iAttackable;
        _iAttackable = _TargetTransfrom.GetComponent<IAttackable>();
        return _iAttackable;
    }

}
