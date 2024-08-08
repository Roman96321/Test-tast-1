using System;
using UnityEngine;

public abstract class BaseHealth : MonoBehaviour, IHealth
{
    public event Action onTakeDamage;

    [SerializeField] protected float _health;

    private float _maxHealth;

    private void Awake()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            throw new Exception("damage is <= 0");

        _health -= damage;

        isDie();
        onTakeDamage?.Invoke();
    }

    public float GetHealth()
    {
        return _health;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public virtual void isDie()
    {
        //клас абстрактний
    }
}