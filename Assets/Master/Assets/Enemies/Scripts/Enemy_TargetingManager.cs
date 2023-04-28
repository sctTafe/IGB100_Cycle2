using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DOSE: 
///     Holds all targetable objects on the map, so the related logic dose not need to be run in each agent 
///     Agents can quire this with 'GetCurrentTargetTransform' to get their current target
/// 
/// </summary>
public class Enemy_TargetingManager : MonoBehaviour
{
    public static Enemy_TargetingManager Instance;

    [Header("Setup")]
    public LayerMask _plantsLayer;
    public float _targetingAreaCheckSphereRadius = 40f; // Should be the same as the radius of the oasis, plus a little
    public float _targatableRefreshInterval = 0.1f;
    public string _player_Tag = "Player";
    public string _golemHeart_Tag = "GolemHeart";

    private Transform _targetablePlayer;
    private Transform _targetableHeart;

    private List<Transform> _targetablePlants = new();
    private float _timeTillCheck;

    //private float _playerRangeOveride;
    //private float _plantRangeOveride;
    //private float _heartRangeOveride;


    private void Start()
    {
        if (Instance == null) 
            Instance = this;
        else Destroy(gameObject);

        TryGet_targetablePlayer();
        TryGet_targetableHeart();

        Timer_Reset();
    }

    private void Update()
    {
        Timer_Run();
    }


    public Transform fn_GetCurrentTargetTransform(Transform agentsTransfrom, float targetingRange)
    {
        ///Targeting Priority Order: Player > Plants > Heart
        // 1) Check if player is in range, 2) check if a plant is in range, 3) if non of the above are in range go to the heart
        Vector3 agentPos = agentsTransfrom.position;

        // --- Check Player ---
        if (Vector3.Distance(TryGet_targetablePlayer().position, agentPos) < targetingRange)
            return TryGet_targetablePlayer();

        // --- Check Plant ---
        float dis_currentDis = 9999;
        Transform trans_currentBest = null;
        float dis;
        foreach (var plantTrans in _targetablePlants)
        {
            dis = Vector3.Distance(plantTrans.position, agentPos);

            if (dis < targetingRange)
            {
                if (dis < dis_currentDis)
                {
                    trans_currentBest = plantTrans;
                    dis_currentDis = dis;
                }
            }                  
        }
        if (trans_currentBest != null)
            return trans_currentBest;

        // --- Return Heart ---
        return TryGet_targetableHeart();
    }


    #region Timer
    private void Timer_Run()
    {
        if (_timeTillCheck > 0f)

            // Increment the timer
            _timeTillCheck -= Time.deltaTime;
        Timer_CheckForEnd();
    }
    private void Timer_CheckForEnd()
    {
        if (_timeTillCheck > 0f)
            return;

        _timeTillCheck = 0;
        // - Timer End -
        GetTargetablePlantsInArea();

        Timer_Reset();


    }
    private void Timer_Reset()
    {
        _timeTillCheck = _targatableRefreshInterval;
    }
    #endregion

    private void GetTargetablePlantsInArea()
    {
        // Clear the targetable objects list
        _targetablePlants.Clear();

        // Perform a sphere cast and check for collisions
        Collider[] colliders = Physics.OverlapSphere(transform.position, _targetingAreaCheckSphereRadius, _plantsLayer);
        foreach (Collider collider in colliders)
        {
            // Check if the collided object has the ITargetable interface
            ITargetable targetable = collider.GetComponent<ITargetable>();
            if (targetable != null)
            {
                if (targetable.fn_IGetTargetableType() == TargetableType.Plant)
                    _targetablePlants.Add(collider.transform);
            }
        }
    }



    private Transform TryGet_targetablePlayer()
    {
        if (_targetablePlayer != null)
            return _targetablePlayer;
        _targetablePlayer = GameObject.FindGameObjectWithTag(_player_Tag).transform;
        return _targetablePlayer;
    }
    private Transform TryGet_targetableHeart()
    {
        if (_targetableHeart != null)
            return _targetableHeart;
        _targetableHeart = GameObject.FindGameObjectWithTag(_golemHeart_Tag).transform;
        return _targetableHeart;
    }

}
