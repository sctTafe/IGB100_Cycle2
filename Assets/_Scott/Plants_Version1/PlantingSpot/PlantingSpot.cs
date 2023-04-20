using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Dose: 
/// - handles plant planting and selection of type of plant
/// Interactions: 
///  - 'PlantingSpot_Interaction' script calls the function in it
///  - 'PlantScript' Instantiates the selected plant (currently only a single type)
/// 
///  Scott Barley, 19/04/2023
/// </summary>
public class PlantingSpot : MonoBehaviour
{
    public GameObject _PlantPrefab;
    
    public Material materialNormal;
    public Material materialSelected;

    private Renderer targetRenderer;

    
    public bool _isPlanted { get; private set; } = false;
    private bool _isUsingMaterialNormal = true;
  
    #region Unity Functions
    void Start()
    {
        Setup_GetRenderer();
    }
    #endregion

    #region Public Functions
    public void fn_SetToSelected(bool isTrue)
    {
        if (isTrue)
        {
            targetRenderer.material = materialSelected;
            _isUsingMaterialNormal = false;
        }
        else
        {
            targetRenderer.material = materialNormal;
            _isUsingMaterialNormal = true;
        }

    }
    public void fn_TryPlantPlant()
    {
        if (_isPlanted == false)
        {
            _isPlanted = true;
            Instantiate(_PlantPrefab, this.transform.position, Quaternion.identity);
            Debug.Log("A plant is now planted");
        }
    }
    #endregion

    #region Private Functions
    private void Setup_GetRenderer()
    {
        /// NOTE: the is a better way of doing this by just attaching a second material with emission and turning that on an off, but for now this was easier
        // If no target renderer is specified, use the renderer on this object
        if (targetRenderer == null)
        {
            targetRenderer = GetComponent<Renderer>();
        }
        // Assign material A to the renderer initially
        targetRenderer.material = materialNormal;
    }
    #endregion
}
