using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameProgressionMng : MonoBehaviour
{
    public UnityEvent _OnGameStart;
    public UnityEvent _OnPlaySecondAudioClip;   // fill with water
    public UnityEvent _OnPlayThridAudioClip;    // plant stuff
    public UnityEvent _OnPlayForthAudioClip;    // narative
    public UnityEvent _OnPlayFithAudioClip;     // wave1
    public UnityEvent _OnProgressTrigger6;      // wave 2   
    public UnityEvent _OnProgressTrigger7;      // final wave
    public UnityEvent _OnProgressTrigger8;      // end game

    [Header("Plants Grown")]
    public TextMeshProUGUI plantsGrownDisplay;
    public int _plantsPlantedCount = 0;

    [Header("Audio Tracks")]
    public float _track1Time;
    public float _track2Time;
    public float _track3Time;
    public float _track4Time;
    public float _track5Time;
    public float _track6Time;
    public float _track7Time;

    [Header("Trigger State")]
    public bool _trigger_WaterRefilled;


    [Header("Progression State")]
    public bool _isTrack1Fin = false;
    public bool _isTrack2Started = false;
    public bool _isTrack2Fin = false;
    public bool _isTrack3Started = false;
    public bool _isTrack3Fin = false;
    public bool _isTrack4Started = false;
    public bool _isTrack4Fin = false;
    public bool _isTrack5Started = false;
    public bool _isTrack5Fin = false;
    public bool _isTrack6Started = false;
    public bool _isTrack6Fin = false;
    public bool _isTrack7Started = false;
    public bool _isTrack7Fin = false;
    public bool _isTrack8Started = false;
    public bool _isTrack8Fin = false;



    void Start()
    {
        _OnGameStart?.Invoke();
        StartCoroutine(CallEventAfterDelay1(_track1Time));
    }

    // Update is called once per frame
    void Update()
    {
        if (plantsGrownDisplay != null)
            plantsGrownDisplay.SetText("Plants Grown: " + _plantsPlantedCount);

        if (_isTrack2Started ==false && _isTrack1Fin == true)
        {
            _isTrack2Started = true;
            StartCoroutine(CallEventAfterDelay2(_track2Time));
            _OnPlaySecondAudioClip?.Invoke();
        }
        
        if(_trigger_WaterRefilled == true && _isTrack2Fin == true && _isTrack3Started == false)
        {
            _isTrack3Started = true;
            StartCoroutine(CallEventAfterDelay3(_track3Time));
            _OnPlayThridAudioClip?.Invoke();
        }
        if ( _isTrack3Fin == true && _isTrack4Started == false)
        {
            _isTrack4Started = true;
            StartCoroutine(CallEventAfterDelay4(_track4Time));
            _OnPlayForthAudioClip?.Invoke();
        }
        if (_plantsPlantedCount >= 5 && _isTrack4Fin == true && _isTrack5Started == false)
        {
            _isTrack5Started = true;
            StartCoroutine(CallEventAfterDelay5(_track5Time));
            _OnPlayFithAudioClip?.Invoke();
        }
        if (_plantsPlantedCount >= 15 && _isTrack5Fin == true && _isTrack6Started == false)
        {
            _isTrack6Started = true;
            StartCoroutine(CallEventAfterDelay6(_track6Time));
            _OnProgressTrigger6?.Invoke();
        }
        if (_plantsPlantedCount >= 30 && _isTrack6Fin == true && _isTrack7Started == false)
        {
            _isTrack7Started = true;
            StartCoroutine(CallEventAfterDelay7(_track7Time));
            _OnProgressTrigger7?.Invoke();
        }

        if (_isTrack7Fin == true && _isTrack8Started == false)
        {
            _isTrack8Started = true;
            _OnProgressTrigger8?.Invoke();
        }

    }

    private IEnumerator CallEventAfterDelay1(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _isTrack1Fin = true;
    }
    private IEnumerator CallEventAfterDelay2(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _isTrack2Fin = true;
    }
    private IEnumerator CallEventAfterDelay3(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _isTrack3Fin = true;
    }
    private IEnumerator CallEventAfterDelay4(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _isTrack4Fin = true;
    }
    private IEnumerator CallEventAfterDelay5(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _isTrack5Fin = true;
    }
    private IEnumerator CallEventAfterDelay6(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _isTrack6Fin = true;
    }
    private IEnumerator CallEventAfterDelay7(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _isTrack7Fin = true;
    }
    private IEnumerator CallEventAfterDelay8(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        _isTrack8Fin = true;
    }

    public void fn_Trigger_WaterRefilled()
    {
        _trigger_WaterRefilled = true;
    }

    public void fn_AddToPlantedPlantsCount()
    {
        _plantsPlantedCount++;
    }
}
