using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Target;

    public float lerpSpeed;
    bool _isFollowing = true;

    // Start is called before the first frame update
    void Start()
    {
        
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
            transform.position = Vector3.Lerp(transform.position, Target.position, lerpSpeed);
        }
    }
}
