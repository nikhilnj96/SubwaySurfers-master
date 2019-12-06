using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployBrands : MonoBehaviour
{
    public GameObject brandPrefab1, brandPrefab2, brandPrefab3, bomb;

    GameObject a;
    List<GameObject> brands = new List<GameObject>();

    int test = 0, testPosition = 30, checkUserPreference = 0;
    float respawnTime = 1f;
    Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-40, Screen.height));
        brands.Add(brandPrefab1);
        brands.Add(brandPrefab2);
        brands.Add(brandPrefab3);
        brands.Add(bomb);

        StartCoroutine(wave());
    }

    void create()
    {
        int i = Random.Range(0, 10) % 4;

        if (checkUserPreference == 0)
        {
            int temp = Random.Range(1, 10);
            if (temp >= 7)
            {
                checkUserPreference = 1;
                Debug.Log("trap coming");
            }
        }
        if (checkUserPreference == 0)
        {
            a = Instantiate(brands[i]) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
        }
        else if (checkUserPreference == 1)
        {
            a = Instantiate(brands[i]) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
            checkUserPreference++;
        }
        else if (checkUserPreference == 2)
        {
            Debug.Log("wohoo");
            a = Instantiate(brands[i]) as GameObject;
            a.transform.position = new Vector2(testPosition, screenBounds.y * 2);

            a = Instantiate(brands[i]) as GameObject;
            a.transform.position = new Vector2(-testPosition, screenBounds.y * 2);
            checkUserPreference = 0;
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
}
