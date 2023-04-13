using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Mover : MonoBehaviour
{
    private const int MinLines = 0;
    private const int MaxLines = 10;

    [SerializeField, Range(MinLines, MaxLines)] private int _countLines;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _speedStrafe;
    [SerializeField] private float _speed;
    [SerializeField] private MoveAnimations _animations;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _snapSpeed;
    [SerializeField] private float _timeToUpSpeed;
    [SerializeField] private float _changeSpeed = 0.05f;
    [SerializeField] private GameObject _effect;
    //[SerializeField] private PlayerEffects _effect;

    private int _startLine;
    private int _nexLine;
    private float _startPositionX;
    private InputHandler _input;
    private int _inputDirection;
    private float _velocity;
    private float _gravity = -9.81f;
    private float _gravityScale = 1;
    private float _maxSpeedStrafe = 11;

    private void Awake()
    {
        _startPositionX = transform.position.x;
        _startLine = _countLines / 2;
        _nexLine = _startLine;
        _input = GetComponent<InputHandler>();
    }

    private void Update()
    {
        if (_speedStrafe < _maxSpeedStrafe)
        {
            _speedStrafe += Time.deltaTime * _changeSpeed;
        }
            _speed += Time.deltaTime * _changeSpeed;

        Move();

        _animations.Move(_inputDirection);

        _velocity += _gravity * _gravityScale * Time.deltaTime;

        _animations.Jumping(_groundChecker._isGrounded);

        if (_groundChecker._isGrounded && _velocity < 0)
        {
            _effect.SetActive(true);
            //_effect.EffectOption(true);
            _velocity = 0;
            var targetPosition = new Vector3(transform.position.x, _groundChecker.SnapPoint.y + _yOffset, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _snapSpeed * Time.deltaTime);
        }

        transform.Translate(new Vector3(0, _velocity, _speed) * Time.deltaTime);
    }

    private void Move()
    {
        var linePosition = (_nexLine - _startLine) * _stepSize + _startPositionX;
        var targetPosition = new Vector3(linePosition, transform.position.y, transform.position.z);

        if (transform.position == targetPosition)
        {
            _inputDirection = 0;
        }

        if (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speedStrafe * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        _input.MovePerformed += SetDirection;
        _input.Jumped += OnJump;
        _input.Slide += OnSlide;
    }

    private void OnDisable()
    {
        _input.MovePerformed -= SetDirection;
        _input.Jumped -= OnJump;
        _input.Slide -= OnSlide;
    }

    private void SetDirection(Vector2 direction)
    {
        _nexLine += (int)direction.normalized.x;
        _nexLine = Mathf.Clamp(_nexLine, MinLines, _countLines);
        _inputDirection = (int)direction.x;
    }

    private void OnJump()
    {
        //if (_groundChecker._isGrounded)
        //{
        //    _animations.SetJumpTrigger();
        //    _velocity = _jumpForce;
        //    _effect.SetActive(false);
        //}

        if (_groundChecker._isGrounded)
        {
            _animations.SetJumpingsTrigger();
            _velocity = _jumpForce;
            _effect.SetActive(false);
        }
    }

    private void OnSlide()
    {
        if (_groundChecker._isGrounded)
        {
            _animations.SetSlide();
        }
    }

}
