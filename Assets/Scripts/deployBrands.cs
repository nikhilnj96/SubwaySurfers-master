using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployBrands : MonoBehaviour
{
    public GameObject brandPrefab1, brandPrefab2, brandPrefab3, bomb;
    public bool testing = false;

    GameObject a, a1, a2;
    List<GameObject> brands = new List<GameObject>();

    int currentLevel, test = 0, testPosition = 20, checkUserPreference = 0;
    float respawnTime = 1f;
    Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 40, Screen.height));
        brands.Add(brandPrefab1);
        brands.Add(brandPrefab2);
        brands.Add(brandPrefab3);
        brands.Add(bomb);

        currentLevel = Game.getLevel();
        if (currentLevel == 3)
        {
            respawnTime = 0.5f;
            brands.Add(bomb);
            brands.Add(bomb);
        }

        StartCoroutine(wave());
    }

    void create()
    {
        if (checkUserPreference == 0)
        {
            int temp = Random.Range(1, 10);
            if (temp >= 7)
            {
                checkUserPreference = 1;
                Debug.Log("decision time");
            }
        }
        if (checkUserPreference == 0)
        {
            a = Instantiate(brands[getIndex()]) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y);
            addBrandsInPlay(a.name, "");
        }
        else if (checkUserPreference == 1)
        {
            a = Instantiate(brands[getIndex()]) as GameObject;
            a.transform.position = new Vector2(0, screenBounds.y);
            addBrandsInPlay(a.name, "");
            checkUserPreference++;
        }
        else if (checkUserPreference == 2)
        {
            float currentPosition = PlayerPrefs.GetFloat("positionX");
            if (currentPosition + testPosition > screenBounds.x || currentPosition - testPosition < -screenBounds.x)
            {
                //Either left or right will go off screen, so try to get the character to center
                a = Instantiate(brands[getIndex()]) as GameObject;
                a.transform.position = new Vector2(0, screenBounds.y);
                addBrandsInPlay(a.name, "");
                Debug.Log("Couldnt send 2 items... Waiting");
            }
            else
            {                
                a1 = Instantiate(brands[getIndex()]) as GameObject;
                a1.transform.position = new Vector2(currentPosition + testPosition, screenBounds.y);
                
                a2 = Instantiate(brands[getIndex()]) as GameObject;
                a2.transform.position = new Vector2(currentPosition - testPosition, screenBounds.y);

                addBrandsInPlay(a1.name, a2.name);
                checkUserPreference = 0;
            }
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

    void addBrandsInPlay(string s1, string s2)
    {
        s1 = s1.Split('(')[0];
        s2 = s2.Split('(')[0];
        if (s1 != "bomb" && s2 != "bomb")
        {
            PlayerPrefs.SetString("brandsInPlay", s1 + ";" + s2);
        }
    }

    int getIndex()
    {
        return Random.Range(0, brands.Count);
    }
}
