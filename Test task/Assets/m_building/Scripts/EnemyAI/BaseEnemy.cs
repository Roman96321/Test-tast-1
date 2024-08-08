using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent), typeof(EnemyState))]
public abstract class BaseEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] protected float _moveDistance;
    [SerializeField] private float _speed;

    [Inject] protected Player _playerTransform;

    private NavMeshAgent _agent;
    private EnemyState _enemyState;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemyState = GetComponent<EnemyState>();

        _agent.speed = _speed;
    }

    private void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance + 0.3f)
            _enemyState.SetDoesNotMoveState();
    }

    public void Move()
    {
        float distance = Vector3.Distance(_playerTransform.transform.position, transform.position);

        if (distance < _moveDistance)
        {
            _agent.SetDestination(transform.position);
            return;
        }

        Vector3 point = PointToMove();
        _agent.SetDestination(point);
    }

    protected virtual Vector3 PointToMove()
    {
        return transform.position;
    }
}