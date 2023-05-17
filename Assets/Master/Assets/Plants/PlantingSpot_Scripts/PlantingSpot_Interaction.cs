using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public int seedcount = 0;
    int currentseed = 0;
    public TextMeshProUGUI seedDisplay;


    private void Update()
    {
        if (seedcount == 351)
        {
            currentseed++;
            seedcount = 0;
        }
        if (seedDisplay != null)
            seedDisplay.SetText("Seed Amount: " + currentseed);
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
            if (currentseed > 0)
            {
                TryPlantPlant();
                currentseed--;
            }        
        }
    }

    private void TryPlantPlant()
    {
        if (_isInteractingWithASpot == false) return;
        if (_currentPlantingSpot == null) return;
        _currentPlantingSpot.GetComponent<PlantingSpot>().fn_TryPlantPlant();

    }
}
