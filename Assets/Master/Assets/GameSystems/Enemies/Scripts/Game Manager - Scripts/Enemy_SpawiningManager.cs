using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy_SpawiningManager : MonoBehaviour
{ 
    public UnityEvent _OnWinGame;
    
    [Header("Dependants")]  
    public Transform[] _spawnPoints; // array of spawn points for enemies
    public GameObject _enemyPrefab_Type1;
    public GameObject _enemyPrefab_Type2;

    [Header("Enemy Wave Settings")]
    //public float timeBetweenWaves = 30f; // time between waves in seconds
    public int _enemiesInWave = 10; // number of enemies per wave   
    public bool isEndless = false; // if true, waves will spawn endlessly

    // -- Private Varaibles --
    private bool _isSpawningWave; 
    private float _timeTillNextWave; 
    private bool _isTimerActive;
    private Coroutine _WasveSpawningCoroutine;
    private int waveCount = 0; // current wave count

    [Header("Time Settings")]
    // Time Based End
    public float timeEnd = 360f;
    private float _timeTillEnd;
    private bool _isEndTimerActive;

    private bool _spawnType1 = false;
    private bool _spawnType2 = false;


    private bool _wave1Started;
    private bool _wave1Finished;




    void Start()
    {
        //WaveTimer_Reset();
        //EndTimer_Reset();
    }

    void Update()
    {
        //WaveTimer_Update();
        //EndTimer_Update();
    }


    public void fn_Trigger_Wave(int waveNo)
    {
        
        if (waveNo == 1)
            Wave1Setup();
        if (waveNo == 2)
            Wave2Setup();
        if (waveNo == 3)
            Wave3Setup();

        _WasveSpawningCoroutine = StartCoroutine(SpawnEnemiesWave());  
        
    }



    private void WaveTimer_Update()
    {
        if (!_isTimerActive) return;

        // decrement time left by time since last frame
        _timeTillNextWave -= Time.deltaTime;
        WaveTimer_CheckEnd();
    }
    private void WaveTimer_CheckEnd()
    {
        if (_timeTillNextWave > 0f) return;

        // Timer Finished
        _timeTillNextWave = 0;
        _isTimerActive = false;

        _WasveSpawningCoroutine = StartCoroutine(SpawnEnemiesWave());
    }
    //private void WaveTimer_Reset()
    //{
    //    //_timeTillNextWave = timeBetweenWaves;
    //    //_isTimerActive = true;
    //}



    private void EndTimer_Update()
    {
        if (!_isEndTimerActive) return;

        _timeTillEnd -= Time.deltaTime;
        EndTimer_CheckEnd();
    }

    private void EndTimer_CheckEnd()
    {
        if (_timeTillEnd > 0f) return;

        // Timer Finished
        _timeTillEnd = 0;
        _isEndTimerActive = false;
        _OnWinGame?.Invoke();
    }

    private void EndTimer_Reset()
    {
        _timeTillEnd = timeEnd;
        _isEndTimerActive = true;
    }


    IEnumerator SpawnEnemiesWave()
    {
        waveCount++;
        // set flag to indicate we're spawning enemies
        _isSpawningWave = true;

        // spawn enemies
        for (int i = 0; i < _enemiesInWave; i++)
        {
                  
            if (_spawnType1)
            {
                Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                GameObject prefabToSpawn = _enemyPrefab_Type1;
                // instantiate enemy prefab at the selected spawn point
                GameObject enemy = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
                enemy.transform.parent = this.transform;
            }

            if (_spawnType2)
            {
                Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                GameObject prefabToSpawn = _enemyPrefab_Type1;
                // instantiate enemy prefab at the selected spawn point
                GameObject enemy = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
                enemy.transform.parent = this.transform;
            }



            // wait a short time before spawning next enemy
            yield return new WaitForSeconds(0.5f);
        }

        _isSpawningWave = false;
        //WaveTimer_Reset();
    }

    private void Wave1Setup()
    {
        _enemiesInWave = 10;
        _spawnType1 = true;
        _spawnType2 = false;
    }
    private void Wave2Setup()
    {
        _enemiesInWave = 20;
        _spawnType1 = false;
        _spawnType2 = true;
    }
    private void Wave3Setup()
    {
        _enemiesInWave = 20;
        _spawnType1 = true;
        _spawnType2 = true;
    }



}
