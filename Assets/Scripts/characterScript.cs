using System;
using UnityEngine;
using UnityEngine.UI;

public class characterScript : MonoBehaviour
{
    public int score = 0;
    public Text display;
    public AudioSource audioData;

    float speedOfCharacterMovement = 2;

    Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-40, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        gameObject.transform.position = new Vector2(transform.position.x + (h * speedOfCharacterMovement), transform.position.y);
        
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

        PlayerPrefs.SetFloat("positionX", transform.position.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*deployBrands Shot = collision.GetComponent<deployBrands>();
        if (Shot != null)
            Debug.Log("*********" + Shot.testing);
        */

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
        writeToCsv(Game.getCSVFileName(Game.getLevel()), score, name, DateTime.Now.ToString("yyyyMMddHHmmssffff"));
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
                string[] s = PlayerPrefs.GetString("brandsInPlay").Split(';');
                string choseThisBrandOverWhichOne = s[0] == name ? s[1]:s[0];
                
                file.WriteLine(data + "," + name + "," + choseThisBrandOverWhichOne + "," + datetime);
            }
        }
        catch(Exception e)
        {
            Debug.Log("Exception" + e);
        }
    }
}
