using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseBullet : MonoBehaviour, IBullet
{
    private float _speed = 0.009f;
    private Transform _transform;
    private float _progress;
    private Rigidbody _rigidbody;

    public float Damage { get; set; }
    public GameObject Target { get; set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        if (Target != null && Target.activeSelf != false)
        {
            _transform.position = Vector3.Lerp(_transform.position, Target.transform.position, _progress);
            _progress += _speed;

            _transform.LookAt(Target.transform);
        }
        else
        {
            RetrnToPool();
        }
    }

    public void DamageTarget(IHealth targetHealth)
    {
        targetHealth.TakeDamage(Damage);
    }

    public void RetrnToPool()
    {
        _rigidbody.velocity = Vector3.zero;
        _progress = 0;
        Target = null;
        gameObject.SetActive(false);
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.Obstacle)
            RetrnToPool();
    }
}