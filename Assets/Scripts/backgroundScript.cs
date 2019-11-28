using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class backgroundScript : MonoBehaviour
{   
    public Text timerInSeconds;

    float speed = 0.5f;
    int maxTime = 30;

    Vector2 screenBounds;

    void Start()
    {
        clearUserDataBeforeGameStart();
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

    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
