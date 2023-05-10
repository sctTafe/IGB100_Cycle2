using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace ScottBarley.IGB100.TESTING
{

    public class VFX_TweenShaderTest : MonoBehaviour
    {
        [Header("Effect Settings")]      
        public float _tweenDuration;
        private Material _material;

        [Header("Shader - Setup")]
        public string _parameterName_EffectColour = "_EffectColour";
        public Color _colour = Color.red;
        public float _HDRIntenisty;     
        public string _parameterName_EffectPower = "_EffectPower";
        public float _effectPower_value = 2f;
        public string _parameterName_EffectVertexDisplacment = "_EffectVertexDisplacment";
        public float _effectVertexDisplacment_value = 0.05f;
        [Header("Shader - Tweened Value")]
        public string _parameterName_EffectPct = "_pctEffectActive";
        public float _EffectPct_MinValue =0f;
        public float _EffectPct_MaxValue =1f;

        private void Awake()
        {
            Material[] mats = GetComponent<MeshRenderer>().materials;
            bool isEffectMatPresent = false;
            foreach (var mat in mats)
            {
                if (mat.HasProperty(_parameterName_EffectPct))
                    _material = mat;
                isEffectMatPresent = true;
            }
            if (!isEffectMatPresent)
                Debug.LogError("VFX_TweenShaderTest: Effect Material Not Found!");
            _material.SetColor(_parameterName_EffectColour, _colour * _HDRIntenisty);
            _material.SetFloat(_parameterName_EffectPct, _EffectPct_MinValue);
        }

        void Start()
        {
            _material.DOFloat(_EffectPct_MaxValue, _parameterName_EffectPct, _tweenDuration).SetLoops(-1, LoopType.Yoyo);
        }
       


    }
}