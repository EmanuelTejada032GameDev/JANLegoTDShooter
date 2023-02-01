using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 0, _maxHealth = 0;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private LootBag _lootBag;

    [SerializeField] private bool _hasHealthBar;
    [SerializeField] private bool _hasLootBag;
    [SerializeField] private bool _isEnemy;
    [SerializeField] private bool _isPlayerHealthSystem; 
    [SerializeField] private bool _invincible;

    [SerializeField] private AudioSource _enemiesDeathAudioSource;
    [SerializeField] private AudioSource _damageTaken;


    [SerializeField] Image[] _heartsSprites;
    [SerializeField] Sprite _fullHeartSprite;
    [SerializeField] Sprite _emptyHeartSprite;

    [SerializeField] GameObject GameOverMenu;
    [SerializeField] private TextMeshProUGUI _enemiesKilledText;


    [SerializeField] private int _enemyValue;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_isPlayerHealthSystem)
            UpdatePlayerHealthUI();
    }

    private void UpdatePlayerHealthUI()
    {
        for (int i = 0; i < _heartsSprites.Length; i++)
        {
            if (i < _currentHealth) _heartsSprites[i].sprite = _fullHeartSprite;
            else
            {
                _heartsSprites[i].sprite = _emptyHeartSprite;
            }
        }
    }

    private void Start()
    {
        _healthBar.StartupHealthBarConfig(_currentHealth);
    }

    public void Heal(int healthAmount)
    {
        if ((_currentHealth + healthAmount) > _maxHealth) return;

        _currentHealth += healthAmount;

        if (_hasHealthBar)
            _healthBar.SetHealth(_currentHealth);
    }

    public void TakeDamage(int damageAmount)
    {


        _currentHealth -= damageAmount;
        _healthBar.SetHealth(_currentHealth);
        if(!_isEnemy)
            _damageTaken.Play();

        if (_currentHealth <= 0)
        {
            if (_isEnemy)
            {
                _enemiesDeathAudioSource.Play();
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
        if (_invincible == true) return;
        _currentHealth -= 1;
        _damageTaken.Play();
        StartCoroutine(Invicibility());

        UpdatePlayerHealthUI();

        if (_currentHealth <= 0)
        {
            _enemiesKilledText.text = (UIManager.Instance.GetEnemiesKilled()).ToString();
            GameOverMenu.SetActive(true);
            if (_hasLootBag)
            {
                _lootBag.DropLoot();
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator Invicibility()
    {
        _invincible = true;
        yield return new WaitForSeconds(2);
        _invincible = false;
    }

}
