using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSpots_Mng : MonoBehaviour
{
    public PlantingSpot[] _plantingSpots;

    void Start()
    {
        Setup_PlantingSpots();
    }

    private void Setup_PlantingSpots()
    {
        // Initialize the array with all the child objects that have the "PlantingSpot" tag
        GameObject[] plantingSpotObjects = GameObject.FindGameObjectsWithTag("PlantingSpot");
        _plantingSpots = new PlantingSpot[plantingSpotObjects.Length];
        for (int i = 0; i < plantingSpotObjects.Length; i++)
            _plantingSpots[i] = plantingSpotObjects[i].GetComponent<PlantingSpot>();
    }


}
