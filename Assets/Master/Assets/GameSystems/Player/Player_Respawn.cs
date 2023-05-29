using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Created by Cameron
/// Updated by Scott
/// 
/// Update Notes:
///     Needs to register collision with the deseart mesh to trigger respawn
/// </summary>

public class Player_Respawn : MonoBehaviour
{
    public Transform _PlayerTransform;
    public float _YHeightThreshold;
    public Transform _PlayerRespawnPointTrans;
    
    void FixedUpdate()
    {
        if (_PlayerTransform.position.y < _YHeightThreshold)
            _PlayerTransform.position = _PlayerRespawnPointTrans.position;
    }

    public void fn_MovePlayerToRespawnPoint() {
        Debug.Log("Player Respawned");
        _PlayerTransform.gameObject.SetActive(false);
        _PlayerTransform.position = _PlayerRespawnPointTrans.position;
        _PlayerTransform.gameObject.SetActive(true);
    }
}
