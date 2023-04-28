using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour, ITargetable
{
    TargetableType _thisTargetableType;

    public TargetableType fn_IGetTargetableType()
    {
        return (_thisTargetableType);
    }

    public float? fn_IGetTargetingRangeOverideValue()
    {
        return null;
    }



}
