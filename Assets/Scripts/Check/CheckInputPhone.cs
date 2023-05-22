using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInputPhone : MonoBehaviour
{
    [SerializeField] private InputPhoneTest _inputPhone;
    [SerializeField] private CheckInputPhone _check;
    [SerializeField] private GameObject _inputScreen;

    private float _elapsedTime;
    private float _firstSeconds = 1f;
    private float _thirdSeconds = 3f;

    private void Update()
    {
        if (_inputScreen.activeSelf != false)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _firstSeconds)
            {
                _inputPhone.enabled = false;
            }

            if (_elapsedTime >= _thirdSeconds)
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
