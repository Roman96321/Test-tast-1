using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletPoolAttack), typeof(SearchObject))]
public class PlayerDoesNotMoveState : MonoBehaviour, IState
{
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _viewEnemyRange;

    private SearchObject _searchObject;
    private BulletPoolAttack _bulletPool;
    private bool _stateActive = false;
    private float _rotateSpeed = 100;

    private void Start()
    {
        _bulletPool = GetComponent<BulletPoolAttack>();
        _searchObject = GetComponent<SearchObject>();

        StartCoroutine(Attack());
        StartCoroutine(LookEnemy());
    }

    public void EnterState()
    {
        _stateActive = true;
    }

    public void ExitState()
    {
        _stateActive = false;
    }

    private IEnumerator LookEnemy()
    {
        while (true)
        {
            if (_stateActive)
            {
                GameObject target = _searchObject.GetObject(_viewEnemyRange, Tag.Enemy);

                if (target != null)
                {
                    Vector3 direction = target.transform.position - transform.position;
                    direction.y = 0;
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
                }
            }

            yield return new WaitForSeconds(0.02f);
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            if (_stateActive)
                _bulletPool.Attack(Tag.Enemy);

            yield return new WaitForSeconds(_attackSpeed);
        }
    }
}