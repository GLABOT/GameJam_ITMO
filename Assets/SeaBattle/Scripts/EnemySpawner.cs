using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _enemySpawnTimer = 2f;
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private bool _canSpawn = true;

    [SerializeField] private int _enemySpeed = 3;
    [SerializeField] private int _enemySpeedOffset = 1;

    private void FixedUpdate()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (!_canSpawn) return;

        int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);

        Vector2 direction;
        if (randomSpawnPointIndex == 0)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        int speed;

        if (Random.Range(0, 2) == 0)
        {
            speed = _enemySpeed + _enemySpeedOffset;
        }
        else
        {
            speed = _enemySpeed - _enemySpeedOffset;
        }

        Instantiate(_enemyPrefab, _spawnPoints[randomSpawnPointIndex].position, Quaternion.identity).GetComponent<Enemy>().InitializeEnemy(direction, speed);
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        _canSpawn = false;

        yield return new WaitForSeconds(_enemySpawnTimer);

        _canSpawn = true;
    }
}
