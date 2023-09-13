using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontroller : MonoBehaviour
{

    [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
    private Vector2 _axisInput = Vector2.zero;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 moveForce = _axisInput * MoveSpeed * Time.fixedDeltaTime;

        _rb.AddForce(moveForce);
    }

    private void OnMove(InputValue value)
    {
        _axisInput = value.Get<Vector2>();
    }

    private void OnUse(InputValue value)
    {

    }
}
