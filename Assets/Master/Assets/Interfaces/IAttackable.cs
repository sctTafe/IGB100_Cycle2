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
    public void Attack(float damageBaseValue);
}
