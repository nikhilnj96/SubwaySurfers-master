using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void startGame()
    {
        Game.resetLevel();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Subway Surfers");
    }

    public void startNextGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Subway Surfers");
    }
}
