using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dose: 
/// - handles interactions with the planting spots
/// Requirments:
/// - Planting Spots must have the tag: "PlantingSpot" for the script to interact
/// Interactions: 
///  - 'PlantingSpot' class functions are called by this script
///  
///  Scott Barley, 19/04/2023
/// </summary>
public class PlantingSpot_Interaction : MonoBehaviour
{
    bool _isInteractingWithASpot = false;
    GameObject _currentPlantingSpot;


    private void Update()
    {
        Handle_PlayerInput();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlantingSpot")
        {
            if (_isInteractingWithASpot == false)
            {
                if (other.gameObject.GetComponent<PlantingSpot>()._isPlanted == false)
                {
                    _isInteractingWithASpot = true;
                    _currentPlantingSpot = other.gameObject;
                    _currentPlantingSpot.GetComponent<PlantingSpot>().fn_SetToSelected(true);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _currentPlantingSpot)
        {
            _isInteractingWithASpot = false;
            _currentPlantingSpot.GetComponent<PlantingSpot>().fn_SetToSelected(false);
            _currentPlantingSpot = null;
        }
    }

    private void Handle_PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryPlantPlant();
        }
    }

    private void TryPlantPlant()
    {
        if (_isInteractingWithASpot == false) return;
        if (_currentPlantingSpot == null) return;
        _currentPlantingSpot.GetComponent<PlantingSpot>().fn_TryPlantPlant();

    }
}
