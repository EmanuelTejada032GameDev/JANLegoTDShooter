using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 0, _maxHealth = 0;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private LootBag _lootBag;

    [SerializeField] private bool _hasHealthBar;
    [SerializeField] private bool _hasLootBag;
    [SerializeField] private bool _isEnemy;

    [SerializeField] private int _enemyValue;

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
            if (_isEnemy)
            {
                UIManager.Instance.UpdateEnemiesKilled(_enemyValue);
            }
            if (_hasLootBag)
            {
                _lootBag.DropLoot();
            }
            Destroy(gameObject);
        }
    }

    public void TakeConstantDamage()
    {
        _currentHealth -= 1;
        if (_currentHealth <= 0)
        {
            if (_hasLootBag)
            {
                _lootBag.DropLoot();
            }
            Destroy(gameObject);
        }
    }
}
