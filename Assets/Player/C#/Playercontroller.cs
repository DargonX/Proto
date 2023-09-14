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

    private Vector2 _axisInput = Vector2.zero;
    private Rigidbody2D _rb;
    private Animator _animator;
    private CHaracterState _currentState;
    private AnimationClip _currentClip;
    private Vector2 _facingDir;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentState = Idle;
    }

    private void Update()
    {
        AnimationClip expectedClip = StateAnimation.GetFacingClipFromState(_currentState, _facingDir);

        if(_currentClip == null || _currentClip != expectedClip)
        {
            _animator.Play(expectedClip.name);
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveForce = _axisInput * MoveForce * Time.fixedDeltaTime;

        _rb.AddForce(moveForce);
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

    }
}
