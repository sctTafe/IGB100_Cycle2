using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{                                                      
    //event EventHandler OnMyEvent;       // can have events
    //int MyInt { get; set; }             // can have property, cannot have feilds 
    void fn_IDamage(float baseDamageValue = 0);
}
