using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _possibleEnemiesPrefabs;
    [SerializeField] private Transform[] _spawnPoints;

    private float _spwanTimer = 0.0f;

    void Update()
    {
        _spwanTimer += Time.deltaTime;
        float spawnInterval = Random.Range(3, 10); 
        if (_spwanTimer >= spawnInterval)
        {
            SpawnEnemy();
            _spwanTimer = 0.0f;
        }
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        Instantiate(_possibleEnemiesPrefabs[Random.Range(0, _possibleEnemiesPrefabs.Count)], spawnPoint.position, Quaternion.identity);
    }
}
