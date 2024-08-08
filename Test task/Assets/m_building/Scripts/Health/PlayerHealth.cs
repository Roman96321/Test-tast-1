using UnityEngine.SceneManagement;

public class PlayerHealth : BaseHealth
{
    public override void isDie()
    {
        if (_health <= 0)
            SceneManager.LoadScene(Scene.GamePlay);
    }
}