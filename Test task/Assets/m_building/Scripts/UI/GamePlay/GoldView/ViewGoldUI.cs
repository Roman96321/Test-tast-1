using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ViewGoldUI : MonoBehaviour
{
    [Inject] private ResourceFeatures _resourceFeatures;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void ChangedText(ResourceType type, int count)
    {
        if (type == ResourceType.Gold)
            _text.text = _resourceFeatures.GetResource(ResourceType.Gold).ToString();
    }

    private void OnEnable()
    {
        _resourceFeatures.onChanged += ChangedText;
    }

    private void OnDisable()
    {
        _resourceFeatures.onChanged -= ChangedText;
    }
}