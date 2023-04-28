using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FallOffMapRespawn : MonoBehaviour
{
    public float _YHeightThreshold;
    public Transform _PlayerRespawnPointTrans;

    void FixedUpdate()
    {
        if (transform.position.y < _YHeightThreshold)
            transform.position = _PlayerRespawnPointTrans.position;
    }
}
