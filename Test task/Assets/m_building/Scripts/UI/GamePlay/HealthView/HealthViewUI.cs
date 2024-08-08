using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthViewUI : MonoBehaviour
{
    [SerializeField] private GameObject _goHealth;

    private Slider _healtBar;
    private IHealth _health;

    private void Awake()
    {
        _health = _goHealth.GetComponent<IHealth>();
        _healtBar = GetComponent<Slider>();
    }

    private void Start()
    {
        _healtBar.maxValue = _health.GetMaxHealth();
        _healtBar.value = _healtBar.maxValue;
    }

    private void ChangeHealthText()
    {
        _healtBar.value = _health.GetHealth();
    }

    private void OnEnable()
    {
        _health.onTakeDamage += ChangeHealthText;
    }

    private void OnDisable()
    {
        _health.onTakeDamage -= ChangeHealthText;
    }
}