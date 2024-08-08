using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SearchObject), typeof(RaycastCheck))]
public class BulletPoolAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _bulletPrefab;

    private RaycastCheck _raycastCheck;
    private SearchObject _searchObject;
    private List<GameObject> _goBullets = new List<GameObject>();
    private List<IBullet> _bullets = new List<IBullet>();
    private int _poolSize = 2;

    private void Awake()
    {
        _searchObject = GetComponent<SearchObject>();
        _raycastCheck = GetComponent<RaycastCheck>();

        AddBulletInPool(_poolSize);
    }

    public void Attack(string targetTag)
    {
        GameObject target = _searchObject.GetObject(_attackRange, targetTag);

        IBullet bullet = _bullets[GetBulletFromPool()];
        GameObject goBullet = _goBullets[GetBulletFromPool()];

        if (target != null && bullet != null)
        {
            if (_raycastCheck.IsHit(target))
                return;

            bullet.Target = target;
            bullet.Damage = _damage;

            goBullet.transform.position = transform.position;
            goBullet.SetActive(true);
        }
    }

    private int GetBulletFromPool()
    {
        for (int i = 0; i < _goBullets.Count; i++)
        {
            if (_goBullets[i].activeSelf == false)
                return i;
        }

        AddBulletInPool(1);
        return _goBullets.Count - 1;
    }

    private void AddBulletInPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var bulletObject = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

            _goBullets.Add(bulletObject);
            _bullets.Add(bulletObject.GetComponent<IBullet>());
        }
    }
}