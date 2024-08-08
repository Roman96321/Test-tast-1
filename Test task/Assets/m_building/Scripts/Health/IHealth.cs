using System;

public interface IHealth
{
    public event Action onTakeDamage;

    public void TakeDamage(float damage);
    public float GetHealth();
    public float GetMaxHealth();
}