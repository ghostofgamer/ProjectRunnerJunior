using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCoinScore : MonoBehaviour
{
    [SerializeField] private CoinScore _coinScore;
    [SerializeField] private CheckCoinScore _check;

    private float _elapsedTime;
    private float _timeEnable = 5f;

    private void Start()
    {
        _coinScore.enabled = false;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= 1)
        {
            _coinScore.enabled = true;
        }
        if (_elapsedTime >= 2)
        {

            _coinScore.enabled = false;
        }
        if (_elapsedTime >= 3)
        {

            _coinScore.enabled = true;
            _check.enabled = false;
        }

    }
}
