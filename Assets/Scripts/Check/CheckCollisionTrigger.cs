using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionTrigger : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private CheckCollisionTrigger _check;

    private float _elapsedTime;
    private float _timeEnable = 5f;

    private void Start()
    {
        _gameOverScreen.enabled = false;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= 1)
        {
            _gameOverScreen.enabled = true;
        }
        if (_elapsedTime >= 2)
        {

            _gameOverScreen.enabled = false;
        }
        if (_elapsedTime >= 3)
        {

            _gameOverScreen.enabled = true;
            _check.enabled = false;
        }

    }
}
