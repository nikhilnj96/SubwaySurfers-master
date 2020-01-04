using System;
using UnityEngine;

public static class Game
{
    public static string[] brandNames = new String[] { "pepsi-blue", "pepsi-black", "pepsi-white", "bomb" };
    public static int maxTime = 40;
    public static void setID()
    {
        PlayerPrefs.SetString("id", DateTime.Now.ToString("yyyyMMddHHmmssffff"));
    }

    public static string getCSVFileName()
    {
        return "user_data.csv";
    }

    public static void incrementLevel()
    {
        PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
    }

    public static void resetLevel()
    {
        PlayerPrefs.SetInt("currentLevel", 1);
    }

    public static int getLevel()
    {
        return PlayerPrefs.GetInt("currentLevel",1);
    }

    public static void increaseScore(string s)
    {
        PlayerPrefs.SetInt(s, PlayerPrefs.GetInt(s, 0)+1);
    }

    public static void resetScore()
    {
        for (int i=0; i<brandNames.Length; i++)
        {
            PlayerPrefs.SetInt(brandNames[i], 0);
        }
    }
}