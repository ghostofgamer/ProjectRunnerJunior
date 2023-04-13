using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedX;
    [SerializeField] private float _changeSpeedY;
    [SerializeField] private float _changeSpeedX;

    private float _offset;
    private float _offsetX;

    private void Update()
    {
        _speed += Time.deltaTime * _changeSpeedY;
        _speedX += Time.deltaTime * _changeSpeedX;
        _offset -= _speed * Time.deltaTime;
        _offsetX -= _speedX * Time.deltaTime;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(_offsetX, _offset);
    }
}
