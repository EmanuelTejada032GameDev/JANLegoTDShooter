using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage();
        }
        Destroy(gameObject);
    }
}
