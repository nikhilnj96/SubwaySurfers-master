using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployBrands : MonoBehaviour
{
    public GameObject brandPrefab;
    public GameObject brandPrefab2;
    public GameObject brandPrefab3;
    public GameObject bomb;

    float respawnTime = 1f;
    Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-20, Screen.height));
        StartCoroutine(wave());
    }

    void create()
    {
        int i = Random.Range(0, 10) % 4;
        if (i == 0)
        {
            GameObject a = Instantiate(brandPrefab) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
        }
        else if (i==1)
        {
            GameObject a = Instantiate(brandPrefab2) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
        } 
        else if (i==2)
        {
            GameObject a = Instantiate(brandPrefab3) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
        }
        else
        {
            GameObject a = Instantiate(bomb) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
        }
        
    }

    IEnumerator wave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            create();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
