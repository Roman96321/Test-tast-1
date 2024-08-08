using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitGame : MonoBehaviour
{
    private void Quit()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(Quit);
    }
}