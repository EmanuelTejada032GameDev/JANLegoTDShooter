using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem collisionHealthSystem = collision.gameObject.GetComponent<HealthSystem>();
        if (collisionHealthSystem != null)
            collisionHealthSystem.TakeDamage(_damage);

        Destroy(gameObject);
    }
}
