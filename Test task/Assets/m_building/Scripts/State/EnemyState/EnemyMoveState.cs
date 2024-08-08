using UnityEngine;

public class EnemyMoveState : MonoBehaviour, IState
{
    private IEnemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<IEnemy>();
    }

    public void EnterState()
    {
        _enemy.Move();
    }

    public void ExitState()
    {
        // Немає поки що сюди написати
    }
}
