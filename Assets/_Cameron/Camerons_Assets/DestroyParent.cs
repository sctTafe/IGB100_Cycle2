using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    public GameObject PlantingSpot_Interaction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlantingSpot_Interaction[] interaction = other.GetComponentsInChildren<PlantingSpot_Interaction>();
            interaction[0].fn_addSeed(1);
            Destroy(transform.parent.gameObject);
        }
    }

}
