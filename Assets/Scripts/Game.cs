using System;
using UnityEngine;

public static class Game
{
    public static void setID()
    {
        PlayerPrefs.SetString("id", DateTime.Now.ToString("yyyyMMddHHmmssffff"));
    }

    public static string getCSVFileName(int level)
    {
        return "user_data_" + PlayerPrefs.GetString("id","") + "_" + level + ".csv";
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
}