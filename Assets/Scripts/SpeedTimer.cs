using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTimer : MonoBehaviour
{
    [SerializeField] private float _speed=10.5f;
    [SerializeField] private float _speedDown=0.5f;
    [SerializeField] private float _changeSpeed;
    [SerializeField] private float _changeSpeedDown;

    private float _minSpeed = 10f;
    private float _minSpeedDown = 0.8f;

    private void Start()
    {
        _speed = _minSpeed;
        _speedDown = _minSpeedDown;
    }

    private void Update()
    {
        SpeedDownChange();
    }

    public float SpeedChange()
    {
        _speed += _changeSpeed;
        return _speed;
    }

    public float SpeedDownChange()
    {
        _speedDown += _changeSpeedDown;
        return _speedDown;
    }
}
