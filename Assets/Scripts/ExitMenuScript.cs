using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenuScript : MonoBehaviour
{

    public Text t1, t2, t3, t4, t5, total;
    string[] brandNames = Game.brandNames;

    void Start()
    {
        if (Game.getLevel() > 3)
        {
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "EXIT";
        }
        else
        {
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "PLAY LEVEL " + Game.getLevel();
        }

        Dictionary<string, int> myMap = new Dictionary<string, int>();

        for (int i=0; i < brandNames.Length; i++)
        {
            myMap.Add(brandNames[i], 0);
        }
        
        t1.text = PlayerPrefs.GetInt(brandNames[0]) + "";
        t2.text = PlayerPrefs.GetInt(brandNames[1]) + "";
        t3.text = PlayerPrefs.GetInt(brandNames[2]) + "";
        t4.text = (PlayerPrefs.GetInt(brandNames[3])*-5) + "";
        int totalInt = PlayerPrefs.GetInt(brandNames[0]) + PlayerPrefs.GetInt(brandNames[1]) + PlayerPrefs.GetInt(brandNames[2]) + (-5*PlayerPrefs.GetInt(brandNames[3]));
        total.text = "Your Score: " + totalInt;
        t5.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        
        if (Game.getLevel() > 3)
        {
            int highScore = Math.Max(0, Math.Max(totalInt, PlayerPrefs.GetInt("highScore")));
            PlayerPrefs.SetInt("highScore", highScore);
            t5.text = "High Score: " + highScore;
        }
    }
}
