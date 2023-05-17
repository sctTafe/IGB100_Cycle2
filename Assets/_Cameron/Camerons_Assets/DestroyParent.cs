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
            PlantingSpot_Interaction.GetComponent<PlantingSpot_Interaction>().seedcount = 351;
            Destroy(transform.parent.gameObject);
        }
    }

}
