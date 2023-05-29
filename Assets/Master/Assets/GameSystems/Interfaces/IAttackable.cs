using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// IS: An Interface for things Enemies can Attack
/// 
/// </summary>
public interface IAttackable 
{
    public void fn_IAttack(float damageBaseValue);
}
