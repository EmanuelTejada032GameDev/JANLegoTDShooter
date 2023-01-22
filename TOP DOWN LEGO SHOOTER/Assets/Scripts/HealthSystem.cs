using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 0, _maxHealth = 0;
    [SerializeField] private HealthBar _healthBar;

    [SerializeField] private bool _hasHealthBar;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        _healthBar.StartupHealthBarConfig(_currentHealth);
    }

    public void Heal(int healthAmount)
    {
        _currentHealth += healthAmount;

        if (_hasHealthBar)
            _healthBar.SetHealth(_currentHealth);
    }

    public void TakeDamage(int damageAmount)
    {

        _currentHealth -= damageAmount;
        _healthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
