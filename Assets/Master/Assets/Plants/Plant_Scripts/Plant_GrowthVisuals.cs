using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_GrowthVisuals : MonoBehaviour
{


    public float _minScale;
    public float _maxScale;
    
    public Material materialNormal;
    public Material materialNeedsWater;

    public SkinnedMeshRenderer plantRenderer;
    public Renderer[] targetRenderers;


    public void fn_SetScale(float scalePct)
    {
        //float currentLocalScale = Mathf.Lerp(_minScale, _maxScale, scalePct);
        //this.transform.localScale = new Vector3(currentLocalScale, currentLocalScale, currentLocalScale);
        plantRenderer.SetBlendShapeWeight(0, scalePct * 100);
    }

    public void fn_SetNeedsWaterVisual(bool isTrue)
    {
        if (isTrue)
        {
            foreach (var rend in targetRenderers)
            {
                rend.material = materialNeedsWater;
            }      
        }
        else
        {
            foreach (var rend in targetRenderers)
            {
                rend.material = materialNormal;
            }
        }
    }




}
