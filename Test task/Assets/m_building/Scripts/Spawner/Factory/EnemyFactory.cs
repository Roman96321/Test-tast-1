using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Dictionary<string, GameObject> _enemys;
    [SerializeField] private GameObject _flyEnemy;
    [SerializeField] private GameObject _terrestrialEnemy;

    [Inject] private DiContainer _container;

    private void Awake()
    {
        SetEnemy();
    }

    private void SetEnemy()
    {
        _enemys = new Dictionary<string, GameObject>();
        _enemys.Add(EnemyType.FlyEnemy, _flyEnemy);
        _enemys.Add(EnemyType.TerrestrialEnemy, _terrestrialEnemy);
    }

    public GameObject Create(Vector3 spawnPoint, string enemyType)
    {
        return _container.InstantiatePrefab(_enemys[enemyType], spawnPoint, Quaternion.identity, null);
    }
}