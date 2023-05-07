using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInputPhone : MonoBehaviour
{
    [SerializeField] private InputPhoneTest _inputPhone;
    [SerializeField] private CheckInputPhone _check;
    [SerializeField] private GameObject _inputScreen;

    private float _elapsedTime;

    private void Start()
    {
        _inputPhone.enabled = false;
    }

    private void Update()
    {
        if (_inputScreen.activeSelf != false)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= 1)
            {
                _inputPhone.enabled = true;
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
        else
        {
            return;
        }
    }
}
