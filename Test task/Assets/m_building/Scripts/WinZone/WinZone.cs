using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(Scene.GamePlay);
    }
}