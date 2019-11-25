using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenuScript : MonoBehaviour
{

    public Text t1, t2, t3, t4, t5, total;

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, int> myMap = new Dictionary<string, int>();

        myMap.Add("pepsi", 0);
        myMap.Add("maggi", 0);
        myMap.Add("dairymilk", 0);
        myMap.Add("bomb", 0);

        using (var reader = new StreamReader("haha.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                //myMap.Add(values[0], myMap[values[0]]++);
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

        t1.text = myMap["pepsi"] + "";
        t2.text = myMap["maggi"] + "";
        t3.text = myMap["dairymilk"] + "";
        t4.text = (-5 * myMap["bomb"]) + "";
        int totalInt = myMap["pepsi"] + myMap["maggi"] + myMap["dairymilk"] + (-5 * myMap["bomb"]);
        total.text = totalInt + "";
        totalInt = Math.Max(0, Math.Max(totalInt, PlayerPrefs.GetInt("highScore")));

        StreamWriter strm = File.CreateText("haha.csv");
        strm.Flush();
        strm.Close();

        PlayerPrefs.SetInt("highScore", totalInt);
        t5.text = "High Score: " + totalInt;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
