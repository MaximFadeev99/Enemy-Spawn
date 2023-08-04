using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private SpawnPoint[] _spawnPoints;   

    private void Awake()
    {
        _spawnPoints = FindObjectsOfType<SpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies() 
    {
        var waitTime = new WaitForSecondsRealtime(2f);
        SpawnPoint spawnPoint;
        Vector3 destination;
        Enemy spawnedEnemy;

        while (true) 
        {
            spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length-1)];
            destination = GenerateDestination();
            spawnedEnemy = SpawnObject(_enemy, spawnPoint);
            StartCoroutine(spawnedEnemy.MoveToTarget(destination));
            yield return waitTime;
        }
    }

    private Vector3 GenerateDestination() 
    {
        float minValue = 0.1f;
        float maxValue = 0.9f;
        float z = 10f;
        float x = Random.Range(minValue, maxValue);
        float y = Random.Range(minValue, maxValue);
        Vector3 spawnPosition = new Vector3(x, y, z);

        return Camera.main.ViewportToWorldPoint(spawnPosition);
    }

    private Enemy SpawnObject(Enemy spawnedObject, SpawnPoint spawnPoint)
    {
        return Instantiate(spawnedObject, spawnPoint.transform.position, spawnedObject.transform.rotation);
    }
}
