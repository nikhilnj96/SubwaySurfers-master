using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundScript : MonoBehaviour
{
    float speed = 5;
    Vector2 screenBounds;
    Vector2 startPos;
    float newPos;
    int maxTime = 10;

    Rigidbody2D rb;

    public float scrollSpeed = 2f;
    public float scrollOffset = 25f;
    public Text timerInSeconds;

    // Use this for initialization
    void Start()
    {
        // Getting backgrounds start position
        startPos = transform.position;
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

    // Update is called once per frame
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

}
