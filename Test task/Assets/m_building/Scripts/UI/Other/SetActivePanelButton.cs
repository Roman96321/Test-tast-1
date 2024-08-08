using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SetActivePanelButton : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void SetActive()
    {
        _panel.SetActive(!_panel.activeSelf);
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(SetActive);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(SetActive);
    }
}