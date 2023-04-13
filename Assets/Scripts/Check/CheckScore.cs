using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScore : MonoBehaviour
{
    [SerializeField] private Score _score;
    private float _elapsedTime;
    private float _timeEnable = 5f;
    [SerializeField] private CheckScore _check;


    private void Start()
    {
        _score.enabled = false;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= 1)
        {
            _score.enabled = true;
            //_check.enabled = false;
        }
        if (_elapsedTime >= 2)
        {

            _score.enabled = false;
        }
        if (_elapsedTime >= 3)
        {

            _score.enabled = true;
            _check.enabled = false;
        }

    }
}
