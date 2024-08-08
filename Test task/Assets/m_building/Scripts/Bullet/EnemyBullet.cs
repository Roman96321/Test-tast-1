using UnityEngine;

public class EnemyBullet : BaseBullet
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.Player)
        {
            DamageTarget(Target.GetComponent<IHealth>());
            RetrnToPool();
        }

        base.OnTriggerEnter(other);
    }
}