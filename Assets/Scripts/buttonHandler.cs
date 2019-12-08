using UnityEngine;

public class buttonHandler : MonoBehaviour
{
    public void onExitClick()
    {
        Game.resetLevel();
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExitMenu");
    }
}
