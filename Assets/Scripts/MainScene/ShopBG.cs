using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBG : MonoBehaviour
{
    public GameObject shop, cost;
    public static GameObject whichCube;
    public GameObject whichCubePrefab;

    private bool activeLose;

    private void Start()
    {
        if (PlayerPrefs.GetString("Now Cube") == "Open")
        {
            cost.SetActive(false);
        }
    }

    private void OnEnable()
    {
        //whichCube = Instantiate(whichCubePrefab, new Vector3(0f, 0f, -5f), Quaternion.identity);
        //whichCube.transform.SetParent(shop.transform, true);

        cost.SetActive(true);
        //shop.SetActive(true);
    }

    private void OnDisable()
    {
        cost.SetActive(false);
        //shop.SetActive(false);

        //Destroy(whichCube);
    }
}
