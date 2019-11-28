using UnityEngine;

public class brands : MonoBehaviour
{
    float speed = 60;

    Rigidbody2D rb;
    Vector2 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    void Update()
    {
        if (transform.position.y < screenBounds.y * -2)
        {
            Destroy(this.gameObject);
        } 
    }
}
