using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints;

    public Wave[] waves;
    public int timeBetweenWaves = 5;

    private GameManagerBehavior _gameManager;

    private float _lastSpawnTime;
    private int _enemiesSpawned = 0;

    private void Start()
    {
        _lastSpawnTime = Time.time;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    private void Update()
    {
        int currentWave = _gameManager.Wave;
        if (currentWave < waves.Length)
        {
            float timeInterval = Time.time - _lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;

            if (((_enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || timeInterval > spawnInterval)
                && _enemiesSpawned < waves[currentWave].maxEnemies)
            {
                _lastSpawnTime = Time.time;

                GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                _enemiesSpawned++;
            }

            if (_enemiesSpawned == waves[currentWave].maxEnemies
                && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                _gameManager.Wave++;
                _gameManager.Gold = Mathf.RoundToInt(_gameManager.Gold * 1.1f);
                _enemiesSpawned = 0;
                _lastSpawnTime = Time.time;
            }
        }
        else
        {
            _gameManager.gameOver = true;
            Debug.Log("You win");
        }
    }
}
