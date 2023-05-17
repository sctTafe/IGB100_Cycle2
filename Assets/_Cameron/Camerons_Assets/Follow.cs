using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public string _player_Tag = "Player";
    private Transform _targetablePlayer;

    public float lerpSpeed;
    bool _isFollowing = true;

    // Start is called before the first frame update
    void Start()
    {
        _targetablePlayer = GameObject.FindGameObjectWithTag(_player_Tag).transform;
    }

    public void StartFollowing()
    {
        _isFollowing = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (_isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, _targetablePlayer.position, lerpSpeed);
        }
    }
}
