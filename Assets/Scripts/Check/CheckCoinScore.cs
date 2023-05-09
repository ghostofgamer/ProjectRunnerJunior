using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCoinScore : MonoBehaviour
{
    [SerializeField] private CoinScore _coinScore;
    [SerializeField] private CheckCoinScore _check;

    private float _elapsedTime;
    private float _firstSeconds = 1f;
    private float _thirdSeconds = 3f;

    private void Start()
    {
        _coinScore.enabled = false;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _firstSeconds)
        {
            _coinScore.enabled = false;
        }

        if (_elapsedTime >= _thirdSeconds)
        {
            _coinScore.enabled = true;
            _check.enabled = false;
        }
    }
}
