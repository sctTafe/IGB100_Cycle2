using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VFX_HitEffect : MonoBehaviour
{
    public MeshRenderer _mR;
    public Material _material;
    public MaterialPropertyBlock _mPB;
    public string _parameterName_isEffectOn;
    public string _parameterName_EffectPct;
    private float _parameterValue = 0.5f;
    private bool _isEffectOn;
    private int _isEffectOn_int;

    private float _timeRemaining;

    private void Awake()
    {
        _mPB = new MaterialPropertyBlock();
        _mR = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        #region Setup
        // Check that a material has been assigned to the script
        if (_material == null)
        {
            Debug.LogError("No material has been assigned to the shader controller script.");
            return;
        }

        // Check that the parameter exists in the shader
        if (!_material.HasProperty(_parameterName_isEffectOn))
        {
            Debug.LogError("The material does not have a property named " + _parameterName_isEffectOn + ".");
            return;
        }

        // Check that the parameter exists in the shader
        if (!_material.HasProperty(_parameterName_EffectPct))
        {
            Debug.LogError("The material does not have a property named " + _parameterName_EffectPct + ".");
            return;
        }


        // Set the parameter value on the material
        _material.SetFloat(_parameterName_EffectPct, _parameterValue);
        _material.SetInt(_parameterName_isEffectOn, _isEffectOn_int);

        #endregion
    }

    public void fn_effectOn()
    {
        _mR.GetPropertyBlock(_mPB);
        _mPB.SetInt(_parameterName_isEffectOn, 1);
        _mR.SetPropertyBlock(_mPB);
    }
    /// <summary>
    /// UNFINSIEHD.....
    /// </summary>
    public void fn_flashHitEffect()
    {
        //DOTween.To(() => GetParamaterFloatValue(), x => SetParamaterFloatValue = x, 1f, 1f);
        _mR.GetPropertyBlock(_mPB);
        _mPB.SetInt(_parameterName_isEffectOn, 1);
        _mR.SetPropertyBlock(_mPB);
    }

    public void Tdoe()
    {
        Vector3 test = new Vector3(_parameterValue, 0, 0);
        //test.DOMove()


        //_parameterValue.DOMove

        //DOTween.To(()=> _parameterValue, x=> _parameterValue)
    }

    void SetParamaterFloatValue(float value)
    {
        _mR.GetPropertyBlock(_mPB);
        _mPB.SetFloat(_parameterName_EffectPct, value);
        _mR.SetPropertyBlock(_mPB);
        
    }
    float GetParamaterFloatValue()
    {
        return _parameterValue;
    }

        
}
