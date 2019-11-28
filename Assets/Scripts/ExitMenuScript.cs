using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenuScript : MonoBehaviour
{

    public Text t1, t2, t3, t4, t5, total;
    string[] brandNames = new String[]{"pepsi-blue","pepsi-black", "pepsi-white", "bomb"};

    void Start()
    {
        Dictionary<string, int> myMap = new Dictionary<string, int>();

        for (int i=0; i < brandNames.Length; i++)
        {
            myMap.Add(brandNames[i], 0);
        }
            
        using (var reader = new StreamReader("user_data.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (myMap.ContainsKey(values[1]))
                {
                    myMap[values[1]]++;
                }
                else
                {
                    myMap.Add(values[1], 1);
                }
            }
        }

        t1.text = myMap[brandNames[0]] + "";
        t2.text = myMap[brandNames[1]] + "";
        t3.text = myMap[brandNames[2]] + "";
        t4.text = (-5 * myMap[brandNames[3]]) + "";
        int totalInt = myMap[brandNames[0]] + myMap[brandNames[1]] + myMap[brandNames[2]] + (-5 * myMap[brandNames[3]]);
        total.text = totalInt + "";
        totalInt = Math.Max(0, Math.Max(totalInt, PlayerPrefs.GetInt("highScore")));
        
        PlayerPrefs.SetInt("highScore", totalInt);
        t5.text = "High Score: " + totalInt;

    }

}
