using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 0 , _maxHealth = 0;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(int healthAmount)
    {
        _currentHealth+=healthAmount;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
