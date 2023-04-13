using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParashutMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedDown;
    [SerializeField] private float _changeSpeed = 0.1f;

    private void Update()
    {
        transform.Translate(0, -_speedDown * Time.deltaTime, -_speed * Time.deltaTime);
    }
}
