using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField]private float _speed = 4f;

    [SerializeField] private int health = 5;

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

    public void TakeDamage()
    {
        health--;
        if(health <= 0) Destroy(gameObject);
    }

    private void ChasePlayer()
    {
        if (_playerTransform != null)
        {
            Vector2 direction = _playerTransform.position - transform.position;
            transform.position += (Vector3)direction.normalized * _speed * Time.deltaTime;
        }
    }
}
