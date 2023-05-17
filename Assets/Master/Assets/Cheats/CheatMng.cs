using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScottBarley.IGB100.V1
{
    public class CheatMng : MonoBehaviour
    {
        [SerializeField] bool _infinitePlayerHealth;
        [SerializeField] bool _infinitePlayerAmmo;
        [SerializeField] bool _infiniteGolemHealth;
        [SerializeField] bool _infinitePlayerSeeds;
      
        [SerializeField] Player_Health _PlayerHealth;
        [SerializeField] ProjectileGun _ProjectileGun;
        [SerializeField] Golem_Health _GolemHealth;
        [SerializeField] PlantingSpot_Interaction _PlantingSpotInteraction;

        // Update is called once per frame
        void Update()
        {
            if (_infinitePlayerHealth)
                _PlayerHealth?.fn_SetHealthToFull();
            if (_infinitePlayerAmmo)
                _ProjectileGun?.fn_SetAmmoFull();
            if (_infiniteGolemHealth)
                _GolemHealth?.fn_SetFullHealth();
            if (_infinitePlayerSeeds)
                _PlantingSpotInteraction?.fn_SetSeedsToMax(); 
        }
    }
}