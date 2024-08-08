using UnityEngine;
using Zenject;

public class OpenGates : MonoBehaviour
{
    [Inject] private Spawner _spawner;

    private void Open()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _spawner.onAllEnemyDie += Open;
    }

    private void OnDisable()
    {
        _spawner.onAllEnemyDie -= Open;
    }
}