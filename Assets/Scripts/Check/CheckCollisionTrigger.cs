using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionTrigger : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private CheckCollisionTrigger _check;

    private float _elapsedTime;
    private float _firstSeconds = 1f;
    private float _thirdSeconds = 3f;

    private void Start()
    {
        _gameOverScreen.enabled = false;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _firstSeconds)
        {
            _gameOverScreen.enabled = false;
        }

        if (_elapsedTime >= _thirdSeconds)
        {
            _gameOverScreen.enabled = true;
            _check.enabled = false;
        }
    }
}
