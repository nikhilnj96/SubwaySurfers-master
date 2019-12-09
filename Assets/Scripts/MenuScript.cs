using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public InputField userInput;

    public void startGame()
    {
        if (userInput.text != "")
        {
            PlayerPrefs.SetString("userID", userInput.text);
            //clearUserDataBeforeGameStart();
            Game.resetScore();
            Game.resetLevel();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Subway Surfers");
        }
    }

    public void startNextGame()
    {
        Game.resetScore();
        if (Game.getLevel() > 3)
        {
            Application.Quit();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Subway Surfers");
    }

    void clearUserDataBeforeGameStart()
    {
        Game.setID();
        StreamWriter strm = File.CreateText(Game.getCSVFileName());
        strm.Flush();
        strm.Close();
    }
}