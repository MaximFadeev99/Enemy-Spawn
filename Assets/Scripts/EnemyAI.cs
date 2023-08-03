using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private SpawnPoint[] _spawnPoints;   

    private void Awake()
    {
        _spawnPoints = FindObjectsOfType<SpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies(true));
    }

    private IEnumerator SpawnEnemies(bool isActive) 
    {
        var waitTime = new WaitForSecondsRealtime(2f);
        SpawnPoint spawnPoint;
        Vector3 destination;
        Enemy spawnedEnemy;

        while (isActive) 
        {
            spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length-1)];
            destination = GenerateDestination();
            spawnedEnemy = spawnPoint.SpawnObject(_enemy);
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
}
