using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletPoolAttack), typeof(EnemyState))]
public class EnemyDoesNotMoveState : MonoBehaviour, IState
{
    [SerializeField] private float _timeOfStillness;
    [SerializeField] private float _attackSpeed;

    private BulletPoolAttack _bulletPool;
    private EnemyState _enemyState;
    private bool _attack = false;

    private void Start()
    {
        _bulletPool = GetComponent<BulletPoolAttack>();
        _enemyState = GetComponent<EnemyState>();

        StartCoroutine(Attack());
    }

    public void EnterState()
    {
        _attack = true;
        StartCoroutine(WaitEndState());
    }

    public void ExitState()
    {
        _attack = false;
    }

    private IEnumerator WaitEndState()
    {
        yield return new WaitForSeconds(_timeOfStillness);
        _enemyState.SetMoveState();
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            if (_attack)
                _bulletPool.Attack(Tag.Player);

            yield return new WaitForSeconds(_attackSpeed);
        }
    }
}