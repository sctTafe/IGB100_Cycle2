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
    [SerializeField] private GameObject _plantSpot_DirtVisuals;
    [SerializeField] private GameObject _PlantPrefab;
    [SerializeField] private Material _materialNormal;
    [SerializeField] private Material _materialSelected;

    private Renderer _targetRenderer;

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
            _targetRenderer.material = _materialSelected;
            _isUsingMaterialNormal = false;
        }
        else
        {
            _targetRenderer.material = _materialNormal;
            _isUsingMaterialNormal = true;
        }

    }
    public void fn_TryPlantPlant(out bool isPlantPlanted)
    {
        if (_isPlanted == false)
        {
            _isPlanted = true;
            GameObject go = Instantiate(_PlantPrefab, this.transform.position, Quaternion.identity);
            go.GetComponent<Plant_Mng>().fn_SetPlantingSpot(this);
            Debug.Log("A plant is now planted");
            isPlantPlanted = true;
        }
        else
        {
            isPlantPlanted = false;
        }
        
    }

    public void fn_SetIsPlanted(bool isPlanted) => _isPlanted = isPlanted;
    #endregion

    #region Private Functions
    private void Setup_GetRenderer()
    {
        /// NOTE: the is a better way of doing this by just attaching a second material with emission and turning that on an off, but for now this was easier
        // If no target renderer is specified, use the renderer on this object
        if (_targetRenderer == null)
        {
            _targetRenderer = _plantSpot_DirtVisuals.GetComponent<Renderer>();
        }
        // Assign material A to the renderer initially
        _targetRenderer.material = _materialNormal;
    }
    #endregion
}
