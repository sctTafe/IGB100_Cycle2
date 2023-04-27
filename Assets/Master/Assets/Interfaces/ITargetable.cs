using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable 
{
    public TargetableType fn_GetTargetableType();    
}

public enum TargetableType
{
    GolemHeart,
    Player,
    Plant,  
}
