using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSpots_PlacementMng : MonoBehaviour
{
    //--- public ---
    [Header("Dependants")]
    public Transform _oasisCenter;
    public GameObject _plantingSpotPrefab;
    public int _numberOfPlantingSpots = 10; 
    
    [Header("Setup Radii")]
    public float _oasisPlantingRadius = 5f; 
    public float _plantingSpotMinimumSeparationDistance = 1f; 
    public float _exclusionRadiusFromCenter = 2f;

    [Header("Setup Other")]
    public bool _isRunOnStartUp;

    //--- private ---
    private Vector3 _oasisCenterPos;
    private List<Vector2> _plantingPointsLocations = new();
    private int _whileLoopItterationMAX = 99999;

    private void Start()
    {
        _oasisCenterPos = _oasisCenter.position;
        if (_isRunOnStartUp)
            fn_Run();
    }

    public void fn_Run()
    {
        GenoratePlantingSpotsList();
        InstantiatePlantingSpots();
    }
    private void GenoratePlantingSpotsList()
    {
        _plantingPointsLocations.Clear();
        int currentWhileLoopItterationCount = 0;
        while (_plantingPointsLocations.Count < _numberOfPlantingSpots && currentWhileLoopItterationCount < _whileLoopItterationMAX)
        {
            currentWhileLoopItterationCount++;
            Vector2 point = Random.insideUnitCircle * _oasisPlantingRadius;

            // check if the point is outside of the excluded radius
            if (point.magnitude > _exclusionRadiusFromCenter)
            {
                bool valid = true;

                // check if the point is too close to any existing points
                foreach (Vector2 existingPoint in _plantingPointsLocations)
                {
                    if (Vector2.Distance(point, existingPoint) < _plantingSpotMinimumSeparationDistance)
                    {
                        valid = false;
                        break;
                    }
                }

                // add the point to the list if it's valid
                if (valid)
                {
                    _plantingPointsLocations.Add(point);
                }
            }
        }

        if (currentWhileLoopItterationCount >= _whileLoopItterationMAX - 1)
            Debug.LogWarning("PlantingSpotPlacementMng: GenoratePlantingSpotsList; While Loop MAX Itteration Exited! Loops Executed: ["+ currentWhileLoopItterationCount +"]");
    }
    private void InstantiatePlantingSpots()
    {
        /// NOTE: Should do a ground check above the point, find the right height and place it there for the real version
        foreach (Vector2 point in _plantingPointsLocations)
        {
            GameObject go =  Instantiate(_plantingSpotPrefab, _oasisCenterPos + new Vector3(point.x, 0f, point.y), Quaternion.identity);
            go.transform.parent = this.transform;
        }
    }
}
