using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 0, _maxHealth = 0;
    [SerializeField] private HealthBar _healthBar;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        _healthBar.StartupHealthBarConfig(_currentHealth);
        StartCoroutine(Decreasehealth());
    }

    IEnumerator Decreasehealth()
    {
        Debug.Log($"Current heallth {_currentHealth}, Max health {_maxHealth}");
        yield return new WaitForSeconds(2);
        _currentHealth--;
        _healthBar.SetHealth(_currentHealth);
        if(_currentHealth > 0)
            StartCoroutine(Decreasehealth());
    }

}
