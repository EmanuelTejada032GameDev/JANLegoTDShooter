using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField]private float _speed = 4f;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if(_playerTransform != null)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        if (_playerTransform != null)
        {
            Vector2 direction = _playerTransform.position - transform.position;
            transform.position += (Vector3)direction.normalized * _speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthSystem playerHealthSystem = collision.GetComponent<HealthSystem>();
            playerHealthSystem.TakeConstantDamage();
        }
    }
}
