﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onExitClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExitMenu");
    }
}
