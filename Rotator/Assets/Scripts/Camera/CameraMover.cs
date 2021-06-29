using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _sizeForIncrease;

    private Camera _camera;

    private Vector3 _currentPosition;

    private void Awake()
    {
        _camera = Camera.main;
        _currentPosition = transform.position;
    }

    public void ButtonUp()
    {
        if (transform.position.y < 40)
            transform.position =
                Vector3.Lerp(transform.position, transform.position * _sizeForIncrease, _sizeForIncrease);
    }


    public void ButtonDown() =>
        transform.position = Vector3.Lerp(transform.position, _currentPosition, _sizeForIncrease);
}