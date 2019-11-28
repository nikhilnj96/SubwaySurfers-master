using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class backgroundScript : MonoBehaviour
{    
    public float scrollSpeed = 2f;
    public float scrollOffset = 25f;
    public Text timerInSeconds;

    float speed = 5;
    int maxTime = 30;

    Rigidbody2D rb;
    Vector2 screenBounds;

    void Start()
    {
        clearUserDataBeforeGameStart();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed*5);
        StartCoroutine(wave());
    }

    IEnumerator wave()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            create();
        }
    }

    void create()
    {
        timerInSeconds.text = "0:" + (--maxTime).ToString();
        if (maxTime == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("ExitMenu");
        }       
    }

    private void OnBecameInvisible()
    {
        gameObject.transform.position = new Vector3(0, screenBounds.y, 0f);
    }

    void clearUserDataBeforeGameStart()
    {
        StreamWriter strm = File.CreateText("user_data.csv");
        strm.Flush();
        strm.Close();
    }

}
