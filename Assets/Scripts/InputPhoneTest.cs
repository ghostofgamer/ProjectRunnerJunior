using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPhoneTest : MonoBehaviour
{
    [SerializeField] private GameObject _inputPhone;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private Mover _mover;
    private Player _player;

    private void Awake()
    {
        if (Application.isMobilePlatform)
        {
            _inputPhone.SetActive(true);
        }
        else
        {
            _inputPhone.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _leftButton.onClick.AddListener(_mover.LeftInputPhone);
        _rightButton.onClick.AddListener(_mover.RightInputPhone);
    }

    private void OnDisable()
    {
        _leftButton.onClick.RemoveListener(_mover.LeftInputPhone);
        _rightButton.onClick.RemoveListener(_mover.RightInputPhone);
    }

    private void Start()
    {
        _mover = GameObject.FindGameObjectWithTag("Player").GetComponent<Mover>();

        //if (Application.isMobilePlatform)
        //{
        //    _inputPhone.SetActive(true);
        //}
        //else
        //{
        //    _inputPhone.SetActive(false);
        //}
    }
}

