using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private GameObject[] _housePrefab;
    [SerializeField] private GameObject[] _yachtPrefab;
    [SerializeField] private GameObject[] _charactersPrefab;
    [SerializeField] private GameObject[] _palmsPrefab;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _pier;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _secondsBetweenSpawnInWater;
    [SerializeField] private float _secondsBetweenSpawnPier;
    [SerializeField] private float _secondsBetweenSpawnHouse;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform[] _spawnPointsCoin;
    [SerializeField] private Transform[] _spawnPointsHouse;
    [SerializeField] private Transform[] _spawnPointsWater;
    [SerializeField] private Transform[] _spawnPointsCharacters;
    [SerializeField] private Transform[] _spawnPointsPalms;

    private float _elapsedTime = 0;
    private float _elapsedTimeInWater = 0;
    private float _elapsedTimeSpawnPier = 0;
    private float _elapsedTimeSpawnHouse = 0;

    private void Start()
    {
        Initialize(_enemyPrefab, _pool);
        Initialize(_coin, _poolCoin);
        Initialize(_pier, _poolPier);
        Initialize(_housePrefab, _poolHouse);
        Initialize(_yachtPrefab, _poolYacht);
        Initialize(_charactersPrefab, _poolCharacters);
        Initialize(_palmsPrefab, _poolPalms);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        _elapsedTimeInWater += Time.deltaTime;
        _elapsedTimeSpawnPier += Time.deltaTime;
        _elapsedTimeSpawnHouse += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy, _pool))
            {
                _elapsedTime = 0;
                int spawnPointsNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[spawnPointsNumber].position);
            }

            if (TryGetObject(out GameObject coin, _poolCoin))
            {
                _elapsedTime = 0;
                int spawnPointsNumber = Random.Range(0, _spawnPointsCoin.Length);
                SetEnemy(coin, _spawnPointsCoin[spawnPointsNumber].position);

                for (int i = 0; i < coin.transform.childCount; i++)
                {
                    coin.transform.GetChild(i).gameObject.SetActive(true);
                }
            }

            if (TryGetObject(out GameObject character, _poolCharacters))
            {
                _elapsedTime = 0;
                int spawnPointsNumber = Random.Range(0, _spawnPointsCharacters.Length);
                SetEnemy(character, _spawnPointsCharacters[spawnPointsNumber].position);
            }

            if (TryGetObject(out GameObject palm, _poolPalms))
            {
                _elapsedTime = 0;
                int spawnPointsNumber = Random.Range(0, _spawnPointsPalms.Length);
                SetEnemy(palm, _spawnPointsPalms[spawnPointsNumber].position);
            }
        }

        if (_elapsedTimeInWater >= _secondsBetweenSpawnInWater)
        {
            if (TryGetObject(out GameObject yacht, _poolYacht))
            {
                _elapsedTimeInWater = 0;
                int spawnPointsNumber = Random.Range(1, _spawnPointsWater.Length);
                SetEnemy(yacht, _spawnPointsWater[spawnPointsNumber].position);
            }
        }

        if (_elapsedTimeSpawnPier >= _secondsBetweenSpawnPier)
        {
            if (TryGetObject(out GameObject pier, _poolPier))
            {
                _elapsedTimeSpawnPier = 0;
                SetEnemy(pier, _spawnPointsWater[0].position);
            }
        }

        if (_elapsedTimeSpawnHouse >= _secondsBetweenSpawnHouse)
        {
            if (TryGetObject(out GameObject house, _poolHouse))
            {
                _elapsedTimeSpawnHouse = 0;
                int spawnPointsNumber = Random.Range(0, _spawnPointsHouse.Length);
                SetEnemy(house, _spawnPointsHouse[spawnPointsNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
        //enemy.GetComponent<EnemyMover>().Init(_speedTimer);
    }
}
