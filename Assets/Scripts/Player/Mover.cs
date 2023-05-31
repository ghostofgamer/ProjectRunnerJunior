using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //[SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _snapSpeed;
    [SerializeField] private float _timeToUpSpeed;
    [SerializeField] private float _changeSpeed = 0.05f;
    [SerializeField] private GameObject _effect;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;



    [SerializeField] private bool _isJumping = false;
    [SerializeField] private bool _comingDown = false;




    private int _startLine;
    private int _nexLine;
    private float _startPositionX;
    private InputHandler _input;
    private int _inputDirection;
    private float _velocity;
    private float _gravity = -9.81f;
    private float _gravityScale = 1;
    private float _maxSpeedStrafe = 11;
    private float _maxSpeed = 25;

    private void Awake()
    {
        _startPositionX = transform.position.x;
        _startLine = _countLines / 2;
        _nexLine = _startLine;
        _input = GetComponent<InputHandler>();
    }

    private void Update()
    {
        Move();
        _animations.Move(_inputDirection);
        _effect.SetActive(true);
        //_velocity += _gravity * _gravityScale * Time.deltaTime;
        //_animations.Jumping(_groundChecker._isGrounded);

        //if (_groundChecker._isGrounded && _velocity < 0)
        //{
        //    _effect.SetActive(true);
        //    _velocity = 0;
        //    var targetPosition = new Vector3(transform.position.x, _groundChecker.SnapPoint.y + _yOffset, transform.position.z);
        //    transform.position = Vector3.MoveTowards(transform.position, targetPosition, _snapSpeed * Time.deltaTime);
        //}

        if (_isJumping == true)
        {
            if (_comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3.65f, Space.World);
            }
            if (_comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3.65f, Space.World);
            }
        }

        if (_speedStrafe < _maxSpeedStrafe)
        {
            _speedStrafe += Time.deltaTime * _changeSpeed;
        }

        if (_speed < _maxSpeed)
        {
            _speed += Time.deltaTime * _changeSpeed;
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

    public void LeftInputPhone()
    {
        SetDirection(new Vector2(-1, 0));
    }

    public void RightInputPhone()
    {
        SetDirection(new Vector2(1, 0));
    }

    public void OnJump()
    {
        //if (_groundChecker._isGrounded)
        //{
        //    _animations.SetJumpingsTrigger();
        //    _velocity = _jumpForce;
        //    _effect.SetActive(false);
        //}
        if (_isJumping == false)
        {
            _isJumping = true;
            _animations.SetJumpingsTrigger();
            StartCoroutine(JumpSequence());
            _effect.SetActive(false);
        }
    }

    private void OnSlide()
    {
        //if (_groundChecker._isGrounded)
        //{
        //    _animations.SetSlide();
        //}
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.6f);
        _comingDown = true;
        yield return new WaitForSeconds(0.6f);
        _isJumping = false;
        _comingDown = false;
        transform.position = new Vector3(transform.position.x, 0.45f, transform.position.z);
    }
}
