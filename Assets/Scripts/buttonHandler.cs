using UnityEngine;

public class buttonHandler : MonoBehaviour
{
    public void onExitClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExitMenu");
    }
}
