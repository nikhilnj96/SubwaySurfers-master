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
            Game.increaseScore(name);
        } 
        else
        {
            display.text = "Score: " + (++score);
            Game.increaseScore(name);
        }
        writeToCsv(Game.getCSVFileName(), name);
    }

    void resetPosition(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }

    void writeToCsv(string path, string picked)
    {
        try
        {
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(@path, true))
            {
                
                string userID = PlayerPrefs.GetString("userID","_");
                string[] s = PlayerPrefs.GetString("brandsInPlay").Split(';');
                if (s[1] != "")
                {
                    string notPicked = (s[0] == picked) ? s[1] : s[0];
                    Debug.Log(picked + "--" + notPicked);
                    file.WriteLine(userID + "," + Game.getLevel() + "," + picked + "," + notPicked);
                }
            }
        }
        catch(Exception e)
        {
            Debug.Log("Exception" + e);
        }
    }
}
