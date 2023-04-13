using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : Pool
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _zSpawn = 0;
    [SerializeField] private float _tileLength = 50;
    [SerializeField] private float _timeHardTemplate;

    private float _elapsedTime = 0;
    private int _numberTile = 5;

    private void Awake()
    {
    }

    private void Start()
    {
        _playerTransform= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InitializeTile();
        
        for (int i = 0; i < _numberTile; i++)
        {
            if (i == 0)
            {
                Spawn("GroundZero");
            }
            else
            {
                Spawn("GroundEasy");
            }
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_playerTransform.position.z - 50f > _zSpawn - (_numberTile * _tileLength))
        {
            if (_elapsedTime < _timeHardTemplate)
            {
                Spawn("GroundMedium");
            }
            else
                Spawn("Ground");
        }

        DeactivatedTile();
    }

    private void Spawn(string tag)
    {
        GameObject tile = Get(tag);

        if (tile != null)
        {
            for (int i = 0; i < tile.transform.childCount; i++)
            {
                tile.transform.GetChild(i).gameObject.SetActive(true);
            }
            tile.transform.position = this.transform.forward * _zSpawn;
            tile.SetActive(true);

        }
        _zSpawn += _tileLength;
    }

    private void DeactivatedTile()
    {
        foreach (var item in _pooledItem)
        {
            if (item.transform.position.z + 50 < _playerTransform.position.z)
            {
                item.SetActive(false);
            }
        }
    }
}
