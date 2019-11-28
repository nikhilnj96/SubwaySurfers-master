using System;
using UnityEngine;
using UnityEngine.UI;

public class characterScript : MonoBehaviour
{
    public int score = 0;
    public Text display;
    public AudioSource audioData;

    float speed = 2;

    Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        gameObject.transform.position = new Vector2(transform.position.x + (h * speed), transform.position.y);

        if (transform.position.x > screenBounds.x)
        {
            resetPosition(screenBounds.x, transform.position.y);
        } 
        else if (transform.position.x < -screenBounds.x)
        {
            resetPosition(-screenBounds.x, transform.position.y);
        }
        else if (transform.position.y > screenBounds.y)
        {
            resetPosition(transform.position.x, screenBounds.y);
        }
        else if (transform.position.y < -screenBounds.y)
        {
            resetPosition(transform.position.x, -screenBounds.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        String name = collision.name.Split('(')[0];
        if (name == "bomb")
        {
            score -= 5;
            display.text = "Score: " + (score);
        } 
        else
        {
            display.text = "Score: " + (++score);
        }
        writeToCsv("user_data.csv", score, name, DateTime.Now.ToString("yyyyMMddHHmmssffff"));
    }

    void resetPosition(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }

    void writeToCsv(string path, int data, string name, string datetime)
    {
        try
        {
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(@path, true))
            {
                file.WriteLine(data + "," + name + "," + datetime);
            }
        } 
        catch(Exception e)
        {
            Debug.Log("Exception" + e);
        }
    }
}
