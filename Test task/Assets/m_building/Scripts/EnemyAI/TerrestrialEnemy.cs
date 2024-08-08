using UnityEngine;

public class TerrestrialEnemy : BaseEnemy
{
    protected float _randomRange = 7;

    protected override Vector3 PointToMove()
    {
        Vector3 randomPoint = new Vector3(_playerTransform.transform.position.x + Random.Range(-_randomRange, _randomRange),
        _playerTransform.transform.position.y, _playerTransform.transform.position.z + Random.Range(-_randomRange, _randomRange));

        Vector3 directionToPoint = (randomPoint - transform.position).normalized;
        float distanceToPoint = Vector3.Distance(transform.position, randomPoint);

        if (distanceToPoint <= _moveDistance)
            return randomPoint;

        Vector3 newTargetPosition = randomPoint - directionToPoint * (distanceToPoint - _moveDistance);
        return newTargetPosition;
    }
}