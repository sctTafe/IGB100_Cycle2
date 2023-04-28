using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable 
{
    public TargetableType fn_IGetTargetableType();
    public float? fn_IGetTargetingRangeOverideValue();
}

public enum TargetableType
{
    GolemHeart,
    Player,
    Plant,  
}
