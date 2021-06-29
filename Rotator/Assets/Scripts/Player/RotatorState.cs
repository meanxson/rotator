using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody))]
public class RotatorState : MonoBehaviour
{
    [SerializeField] private float _rotationForce;

    private float _defaultForce;
    private Rigidbody _rigidbody;
    private PlayerStateMachine _state;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _state = GetComponent<PlayerStateMachine>();
        _defaultForce = _rotationForce;
    }

    private void FixedUpdate() => Rotate();

    private void Rotate()
    {
        if (Input.GetMouseButton(0) && _state.State == PlayerState.Rotate)
        {
            _rigidbody.AddTorque(Vector3.up * (_defaultForce * Time.fixedDeltaTime), ForceMode.Impulse);
            _defaultForce += Time.fixedDeltaTime;
        }
    }
}