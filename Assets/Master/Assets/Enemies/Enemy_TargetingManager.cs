using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TargetingManager : MonoBehaviour
{
    public float _TargatableRefreshInterval = 0.1f; 
    public float _TargetingAreaCheckSphereRadius = 1.0f;



    private float _timeTillCheck;
    private List<Transform> _targetablePlayers = new ();
    private List<Transform> _targetablePlants = new();
    private List<Transform> _targetableHeart = new();



    private void Update()
    {
        Timer_Run();
    }

    private void Timer_Run()
    {
        // Increment the timer
        _timeTillCheck -= Time.deltaTime;
        Timer_CheckForEnd();
    }
    private void Timer_CheckForEnd()
    {
        if (_timeTillCheck > 0f)
            return;

        // - Timer End -
            CastSphere();

            // Reset the timer
            _timeTillCheck = _TargatableRefreshInterval;
    }

    private void CastSphere()
    {
        // Clear the targetable objects list
        _targetableHeart.Clear();

        // Perform a sphere cast and check for collisions
        Collider[] colliders = Physics.OverlapSphere(transform.position, _TargetingAreaCheckSphereRadius);
        foreach (Collider collider in colliders)
        {
            // Check if the collided object has the ITargetable interface
            ITargetable targetable = collider.GetComponent<ITargetable>();
            if (targetable != null)
            {
                if (targetable.fn_GetTargetableType() == TargetableType.GolemHeart )
                    _targetableHeart.Add(collider.transform);

                if (targetable.fn_GetTargetableType() == TargetableType.Plant)
                    _targetablePlants.Add(collider.transform);

                if (targetable.fn_GetTargetableType() == TargetableType.Player)
                    _targetablePlayers.Add(collider.transform);

            }
        }
    }

    private void PutTargetablesInCorrectList()
    {

    }


}
