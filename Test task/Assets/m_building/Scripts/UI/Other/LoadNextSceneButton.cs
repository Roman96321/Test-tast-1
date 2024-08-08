using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadNextSceneButton : MonoBehaviour
{
    [SerializeField] private string _nextScene;

    private void NextScene()
    {
        SceneManager.LoadScene(_nextScene);
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(NextScene);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(NextScene);
    }
}