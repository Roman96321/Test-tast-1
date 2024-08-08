using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(EnemyFactory))]
public class Spawner : MonoBehaviour
{
    public Action onSpawnAllEnemy;
    public Action onAllEnemyDie;

    [SerializeField] private int _spawnTerrestrialEnemy;
    [SerializeField] private int _spawnFlyEnemy;
    [SerializeField] private Transform[] point = new Transform[4];

    private List<GameObject> _allSpawnedEnemy = new List<GameObject>();
    private EnemyFactory _enemyFactory;
 
    private void Start()
    {
        _enemyFactory = GetComponent<EnemyFactory>();
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnTerrestrialEnemy; i++)
            _allSpawnedEnemy.Add(_enemyFactory.Create(RandomPoint(), EnemyType.TerrestrialEnemy));

        for (int i = 0; i < _spawnFlyEnemy; i++)
            _allSpawnedEnemy.Add(_enemyFactory.Create(RandomPoint(), EnemyType.FlyEnemy));

        onSpawnAllEnemy?.Invoke();
        StartCoroutine(CheckDeadEnemy());
    }

    private Vector3 RandomPoint()
    {
        float t1 = Random.Range(0f, 1f);
        float t2 = Random.Range(0f, 1f);

        Vector3 randomPointOnLine1 = Vector3.Lerp(point[0].position, point[1].position, t1);
        Vector3 randomPointOnLine2 = Vector3.Lerp(point[2].position, point[3].position, t2);

        Vector3 spawnPosition = Vector3.Lerp(randomPointOnLine1, randomPointOnLine2, Random.Range(0f, 1f));
        return spawnPosition;
    }

    private IEnumerator CheckDeadEnemy()
    {
        yield return new WaitForSeconds(2);

        foreach (var enemy in _allSpawnedEnemy)
        {
            if (enemy != null)
            {
                yield return StartCoroutine(CheckDeadEnemy());
                yield return null;
            }
        }

        onAllEnemyDie?.Invoke();
    }
}