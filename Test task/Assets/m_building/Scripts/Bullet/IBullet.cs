using UnityEngine;

public interface IBullet
{
    public float Damage { get; set; }
    public GameObject Target { get; set; }

    public void MoveToTarget();
    public void DamageTarget(IHealth targetHealth);
}