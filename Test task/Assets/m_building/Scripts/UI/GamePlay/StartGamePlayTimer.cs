using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class StartGamePlayTimer : MonoBehaviour
{
    [SerializeField] private Button[] _allInteractableButton;

    [Inject] private Spawner _spawner;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void StartCountdown()
    {
        Time.timeScale = 0;
        SetInteractable(false);
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        float remainingTime = 3;

        while (remainingTime > 0)
        {
            _text.text = remainingTime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            remainingTime--;
        }

        Time.timeScale = 1;
        SetInteractable(true);

        Destroy(gameObject);
    }

    private void SetInteractable(bool active)
    {
        for (int i = 0; i < _allInteractableButton.Length; i++)
            _allInteractableButton[i].interactable = active;
    }

    private void OnEnable()
    {
        _spawner.onSpawnAllEnemy += StartCountdown;
    }

    private void OnDisable()
    {
        _spawner.onSpawnAllEnemy -= StartCountdown;        
    }
}