using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 5f;
    private Rigidbody2D _rigidBody2D;
    [SerializeField]private Weapon _weapon;

    Vector2 _moveDirection;
    Vector2 _mousePosition;

    private void Awake()
    {
        _rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    //Change input way to new input system, handle movemnt and inputs different
    private void Update()
    {
        _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetMouseButtonDown(0))
        {
            // Change to attack , since melee wepon does not fire
            _weapon.Fire();
        }

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _rigidBody2D.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);

        Vector2 aimDirection = _mousePosition - _rigidBody2D.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        _rigidBody2D.rotation = aimAngle;
    }
}
