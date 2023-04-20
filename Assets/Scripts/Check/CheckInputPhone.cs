using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInputPhone : MonoBehaviour
{
    [SerializeField] private InputPhoneTest _inputPhone;
    private float _elapsedTime;
    private float _timeEnable = 5f;
    [SerializeField] private CheckInputPhone _check;


    private void Start()
    {
        _inputPhone.enabled = false;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= 1)
        {
            _inputPhone.enabled = true;
            //_check.enabled = false;
        }
        if (_elapsedTime >= 2)
        {

            _inputPhone.enabled = false;
        }
        if (_elapsedTime >= 3)
        {

            _inputPhone.enabled = true;
            _check.enabled = false;
        }

    }
}
