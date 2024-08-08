using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour
{
    private void Pause()
    {
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(Pause);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(Pause);
    }
}