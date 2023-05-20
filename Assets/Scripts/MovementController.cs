using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Vector2 _movementAxis;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _movementAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (_movementAxis.magnitude == 0) return;

        _movementAxis = _movementAxis.magnitude > 1f ? _movementAxis.normalized : _movementAxis;
        transform.Translate(_movementAxis * (_moveSpeed * Time.deltaTime));
    }
}
