using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ResumedButton : MonoBehaviour
{
    private void Resumed()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(Resumed);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(Resumed);
    }
}