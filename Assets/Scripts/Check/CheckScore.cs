using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScore : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private CheckScore _check;

    private float _elapsedTime;
    private float _firstSeconds = 1f;
    private float _secondSeconds = 2f;
    private float _thirdSeconds = 3f;


    private void Start()
    {
        _score.enabled = false;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _firstSeconds)
        {
            _score.enabled = true;
        }

        if (_elapsedTime >= _secondSeconds)
        {

            _score.enabled = false;
        }

        if (_elapsedTime >= _thirdSeconds)
        {
            _score.enabled = true;
            _check.enabled = false;
        }
    }
}
