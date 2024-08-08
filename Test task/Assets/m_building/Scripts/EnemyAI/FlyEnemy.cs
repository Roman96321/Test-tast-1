using UnityEngine;

public class FlyEnemy : BaseEnemy
{
    protected override Vector3 PointToMove()
    {
        Vector3 playerPosition = _playerTransform.transform.position;

        Vector3 directionToPlayer = (playerPosition - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

        if (distanceToPlayer <= _moveDistance)
            return playerPosition;

        Vector3 newTargetPosition = playerPosition - directionToPlayer * (distanceToPlayer - _moveDistance);
        return newTargetPosition;
    }
}