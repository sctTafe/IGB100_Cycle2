using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Health : MonoBehaviour, ITargetable
{
    #region ITargetable
    public TargetableType fn_GetTargetableType()
    {
        return TargetableType.Plant;
    }

    public float? fn_GetTargetingRangeOverideValue()
    {
        return null;
    }
    #endregion


    void Start()
    {
        
    }

    void Update()
    {
        
    }


}
