using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontroller : MonoBehaviour
{

    [field: SerializeField] public float MoveForce { get; private set; }
    [field: SerializeField] public CHaracterState Idle { get; private set; }
    [field: SerializeField] public CHaracterState Walk { get; private set; }
    [field: SerializeField] public CHaracterState Use { get; private set; }

    [field: SerializeField] public StateAnimationDictionary StateAnimation { get; private set; }
    [field: SerializeField] public float WalkVelocityTreshold { get; private set; } = 0.05f;

    public CHaracterState CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            if(_currentState != value)
            {
                _currentState = value;
                ChangeClip();
                _timeToEndAnimation = _currentClip.length;
            }
        }
    }

    private Vector2 _axisInput = Vector2.zero;
    private Rigidbody2D _rb;
    private Animator _animator;
    private CHaracterState _currentState;
    private AnimationClip _currentClip;
    private Vector2 _facingDir;
    private float _timeToEndAnimation = 0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        CurrentState = Idle;
    }

    private void Update()
    {
        _timeToEndAnimation = Mathf.Max(_timeToEndAnimation - Time.deltaTime, 0);

        if (_currentState.CanExitWhilePlaying || _timeToEndAnimation <= 0)
        {
            if (_axisInput != Vector2.zero && _rb.velocity.magnitude > WalkVelocityTreshold)
            {
                CurrentState = Walk;
            }
            else
            {
                CurrentState = Idle;
            }

            ChangeClip();
        }
    }

    private void ChangeClip()
    {
        AnimationClip expectedClip = StateAnimation.GetFacingClipFromState(_currentState, _facingDir);

        if (_currentClip == null || _currentClip != expectedClip)
        {
            _animator.Play(expectedClip.name);
            _currentClip = expectedClip;
        }
    }

    private void FixedUpdate()
    {
        if (_currentState.CanMove)
        {
            Vector2 moveForce = _axisInput * MoveForce * Time.fixedDeltaTime;
            _rb.AddForce(moveForce);
        }
    }

    private void OnMove(InputValue value)
    {
        _axisInput = value.Get<Vector2>();

        if(_axisInput != Vector2.zero)
        {
            _facingDir = _axisInput;
        }
    }

    private void OnUse(InputValue value)
    {
        CurrentState = Use;
    }
}
