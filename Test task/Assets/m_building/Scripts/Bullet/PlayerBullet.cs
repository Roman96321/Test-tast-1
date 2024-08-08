using UnityEngine;

public class PlayerBullet : BaseBullet
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.Enemy)
        {
            DamageTarget(Target.GetComponent<IHealth>());
            RetrnToPool();
        }

        base.OnTriggerEnter(other);
    }
}