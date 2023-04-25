using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SpawiningManager : MonoBehaviour
{
    [Header("Dependants")]
    public GameObject _enemyPrefab;
    public Transform[] _spawnPoints; // array of spawn points for enemies

    [Header("Enemy Wave Settings")]
    public float timeBetweenWaves = 30f; // time between waves in seconds
    public int enemiesPerWave = 5; // number of enemies per wave   
    public bool isEndless = false; // if true, waves will spawn endlessly

    // -- Private Varaibles --
    private bool _isSpawningWave; 
    private float _timeTillNextWave; 
    private bool _isTimerActive;
    private Coroutine _WasveSpawningCoroutine;
    private int waveCount = 0; // current wave count


    void Start()
    {
        WaveTimer_Reset();
    }

    void Update()
    {
        WaveTimer_Update();
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
    private void WaveTimer_Reset()
    {
        _timeTillNextWave = timeBetweenWaves;
        _isTimerActive = true;
    }


    IEnumerator SpawnEnemiesWave()
    {
        waveCount++;
        // set flag to indicate we're spawning enemies
        _isSpawningWave = true;

        // spawn enemies
        for (int i = 0; i < enemiesPerWave; i++)
        {
            // select a random spawn point from the array
            int spawnIndex = Random.Range(0, _spawnPoints.Length);
            Transform spawnPoint = _spawnPoints[spawnIndex];

            // instantiate enemy prefab at the selected spawn point
            GameObject enemy = Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemy.transform.parent = this.transform;

            // wait a short time before spawning next enemy
            yield return new WaitForSeconds(0.5f);
        }

        _isSpawningWave = false;
        WaveTimer_Reset();
    }





}
