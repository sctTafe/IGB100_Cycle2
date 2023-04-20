using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float _totalGrowthTime;
    public int _numberOfTimeItRequiresWateringToGrow = 2;
    public Plant_GrowthVisuals _plantGameObject;

    private float _growthPercentagePerSecond; // Percentage of total scale to change per second
    private List<float> _pointPlantNeedsWater_List = new();
    private float _currentGrowth_pct = 0f;
    private bool _isFinishedGrowing = false;
    private bool _isInNeedOfWater = false;



    #region Unity Functions
    void Start()
    {
        _plantGameObject.gameObject.SetActive(false);           // turn off so visuals can be updated before it is displayed
        SetupWateringPoints();                                  // populate the watering points list
        _growthPercentagePerSecond = _totalGrowthTime / 100;    // calculate growth rate
        UpdatePlantGrowthVisuals();                             // updated visuals
        _plantGameObject.gameObject.SetActive(true);            // turn on
    } 
    void Update()
    {
        if (!_isFinishedGrowing)    // stop running loop logic after its grown
        {
            if (!_isInNeedOfWater)  // pause growth if its in need of watering
            {
                CheckIfWateringPointHasBeenReached();
                _currentGrowth_pct = _currentGrowth_pct + _growthPercentagePerSecond * Time.deltaTime;
                UpdatePlantGrowthVisuals();

                // check if finished growing
                if (_currentGrowth_pct >= 1)
                    _isFinishedGrowing = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet_Water")
        {
            if (_isInNeedOfWater)
            {
                _isInNeedOfWater = false;
                Destroy(collision.gameObject); // this should be somewhere in the bullet logic 
            }
        }
    }

    #endregion

    #region Private Functions
    private void UpdatePlantGrowthVisuals() => _plantGameObject.fn_SetScale(_currentGrowth_pct);
    private void CheckIfWateringPointHasBeenReached()
    {
        if (_pointPlantNeedsWater_List.Count == 0)
            return;

        if (_currentGrowth_pct > _pointPlantNeedsWater_List[0])
        {
            _isInNeedOfWater = true;
            _plantGameObject.fn_SetNeedsWaterVisual(true);
            _pointPlantNeedsWater_List.RemoveAt(0);
        }

    }
    private void SetupWateringPoints()
    {
        for (int i = 1; i < _numberOfTimeItRequiresWateringToGrow + 1; i++)
        {
            float pctToSetPlantTONeedingWater = Mathf.Lerp(0f, 1f, i * 1.0f / (_numberOfTimeItRequiresWateringToGrow * 1.0f + 1));
            _pointPlantNeedsWater_List.Add(pctToSetPlantTONeedingWater);
        }
    }
    #endregion
}
