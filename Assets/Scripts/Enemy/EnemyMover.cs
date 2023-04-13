using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private SpeedTimer _speedTimer;
    private float _speed;
    private float _speedDown;
    [SerializeField] private bool _isParashute;

    private bool _isInitialize;

    private void Update()
    {

        if (_isInitialize)
        {
            if (_isParashute == true)
            {
                _speedDown = _speedTimer.SpeedDownChange();
            }

            _speed = _speedTimer.SpeedChange();
            transform.Translate(0, -_speedDown * Time.deltaTime, -_speed * Time.deltaTime);
        }
    }

    public void Init(SpeedTimer speedTimer)
    {
        _speedTimer = speedTimer;
        _isInitialize = true;
    }
}
