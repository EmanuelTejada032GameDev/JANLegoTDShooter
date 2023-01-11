using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
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
        Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
