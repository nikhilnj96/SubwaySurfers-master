using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Subway Surfers");
    }
}
