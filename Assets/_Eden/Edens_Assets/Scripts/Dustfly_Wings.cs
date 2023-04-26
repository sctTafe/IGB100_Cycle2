using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustfly_Wings : MonoBehaviour
{
    // create public for the wing flapping -E
    public Transform leftWing;
    public Transform rightWing;

    // record current time in animation and how the wings move -E
    float currentAnimTime = 0;
    public float flapSpeed = 3;
    public float flapAngle = 37;
    public AnimationCurve flapCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);


    // Update is called once per frame
    void Update()
    {
        currentAnimTime += Time.deltaTime * flapSpeed;
        leftWing.localEulerAngles = Vector3.back * ((flapCurve.Evaluate(currentAnimTime)*flapAngle*2)-flapAngle);
        rightWing.localEulerAngles = -leftWing.localEulerAngles;
    }
}
