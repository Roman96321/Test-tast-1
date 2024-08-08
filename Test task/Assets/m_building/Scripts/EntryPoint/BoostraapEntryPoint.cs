using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoostraapEntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _loadingWindow;

    private float _loadingTime = 1.5f;

    private IEnumerator Start()
    {
        Instantiate(_loadingWindow);

        Application.targetFrameRate = 30;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        yield return new WaitForSeconds(_loadingTime);

        SceneManager.LoadScene(Scene.MainMenu);
    }
}