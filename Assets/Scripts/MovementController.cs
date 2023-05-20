using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public void Move(Vector2 axis)
    {
        transform.Translate(axis * (_moveSpeed * Time.deltaTime));
    }
}
