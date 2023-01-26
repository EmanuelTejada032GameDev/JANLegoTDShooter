using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 15f;
    private Rigidbody2D _rigidBody2D;    
    [SerializeField] private Weapon _weapon;

    //Horrible weapon setup needs to be fix to better architecture 

    // BodyPrefabs
    [SerializeField] private GameObject _holdingNormalGunBodyPrefab;
    [SerializeField] private GameObject _holdingLargeGunBodyPrefabb;
    
    // Weapons
    [SerializeField] private GameObject _miniUziPrefab;
    [SerializeField] private GameObject _shotgunPrefab;
    [SerializeField] private GameObject _handgunPrefab;



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

        if (Input.GetMouseButton(0))
        {
            // Logic to fire with holding mouse button
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

    private void EquipWeapon(GameObject weaponPrefab)
   {
        //Horrible code need to be fix in here

        string cleanedName = weaponPrefab.name.Split(" ")[0];

        switch (cleanedName)
        {
            case "ShotGun":
                _shotgunPrefab.SetActive(true);
                _miniUziPrefab.SetActive(false);
                _handgunPrefab.SetActive(false);
                _weapon = _shotgunPrefab.gameObject.GetComponent<Weapon>();
                _holdingNormalGunBodyPrefab.SetActive(false);
                _holdingLargeGunBodyPrefabb.SetActive(true);
                break;
            case "MiniUzi":
                _shotgunPrefab.SetActive(false);
                _miniUziPrefab.SetActive(true);
                _handgunPrefab.SetActive(false);
                _weapon = _miniUziPrefab.gameObject.GetComponent<Weapon>();
                _holdingNormalGunBodyPrefab.SetActive(false);
                _holdingLargeGunBodyPrefabb.SetActive(true);
                break;
            case "Handgun":
                _shotgunPrefab.SetActive(false);
                _miniUziPrefab.SetActive(false);
                _handgunPrefab.SetActive(true);
                _weapon = _handgunPrefab.gameObject.GetComponent<Weapon>();
                _holdingNormalGunBodyPrefab.SetActive(true);
                _holdingLargeGunBodyPrefabb.SetActive(false);
                break;
        }
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            EquipWeapon(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
