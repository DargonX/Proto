using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontroller : MonoBehaviour
{

    [field: SerializeField] public float MoveForce { get; private set; }
    [field: SerializeField] public DirectionalAnimationSet Idle { get; private set; }

    private Vector2 _axisInput = Vector2.zero;
    private Rigidbody2D _rb;
    private Animator _animator;
    private DirectionalAnimationSet _currentSet;
    private AnimationClip _currentClip;
    private Vector2 _facingDir;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentSet = Idle;
    }

    private void Update()
    {
        AnimationClip expectedClip = _currentSet.GetFcingClip(_facingDir);

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
