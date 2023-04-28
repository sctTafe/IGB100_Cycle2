using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{

    public float _attackRange = 5f;
    public float _attackRate = 1f;
    public float _attackDamage = 10f

    private Transform _targetTrans;
    private float nextAttackTime = 0f;
    private IAttackable _iAttackable;

    private void Update()
    {
        if (_targetTrans == null)
            return;

        float distanceToTarget = Vector3.Distance(transform.position, _targetTrans.position);

        if (distanceToTarget <= _attackRange && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / _attackRate;
        }
    }


    public void fn_SetTarget(Transform targetTrans)
    {
        _targetTrans = targetTrans;

        if (_targetTrans == null)
            _iAttackable = _targetTrans.GetComponent<IAttackable>();
        else
            _iAttackable = null;
    }

    private void Attack()
    {
        if (_iAttackable == null)
            return;



    }


}
