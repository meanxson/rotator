using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _countOfEnemy;
    [SerializeField] private int _spawnRate;

    private SpawnPoint[] _enemySpawnPoints;
    private Coroutine _spawnEnemy;

    private void Awake() => _enemySpawnPoints = FindObjectsOfType<SpawnPoint>();

    private void Start() => _spawnEnemy = StartCoroutine(SpawnEnemy());

    private IEnumerator SpawnEnemy()
    {
        for (var i = 0; i < _countOfEnemy; i++)
        {
            Instantiate(_enemy.gameObject,
                _enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Length)].transform.position,
                Quaternion.identity);
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}