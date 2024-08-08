using UnityEngine;

public class DamageForCollision : MonoBehaviour
{
    [SerializeField] private float _damage;

    private IHealth _health;

    private void Start()
    {
        _health = GetComponent<IHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == Tag.Enemy)
            _health.TakeDamage(_damage);
    }
}