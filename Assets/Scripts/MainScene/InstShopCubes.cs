using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstShopCubes : MonoBehaviour
{
    [SerializeField]private GameObject shopParent;

    public GameObject shopCubes, shop;
    public GameObject shopCubesPrefab;
    public GameObject[] cubes;
    public GameObject[] cubesPrefab;

    private void OnEnable()
    {
        //if (cubes.Length != 5)
        //{
        //    //shopCubes = Instantiate(shopCubesPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        //    //shopCubes.transform.SetParent(shop.transform, true);

        //    cubes = new GameObject[cubesPrefab.Length];
        //    for (int i = 0; i < cubesPrefab.Length; i++)
        //    {
        //        cubes[i] = Instantiate(cubesPrefab[i]) as GameObject;
        //    }

        //    shopParent = GameObject.FindGameObjectWithTag("Shop Cubes");
        //    cubes[0].transform.parent = shopParent.transform;
        //    cubes[1].transform.parent = shopParent.transform;
        //    cubes[2].transform.parent = shopParent.transform;
        //    cubes[3].transform.parent = shopParent.transform;
        //    cubes[4].transform.parent = shopParent.transform;
        //}

        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].SetActive(true);
        }

        shopCubes.SetActive(true);
    }

    private void OnDisable()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].SetActive(false);
        }

        shopCubes.SetActive(false);
    }

    public void SpawnCubes()
    {
        cubes = new GameObject[cubesPrefab.Length];
        for (int i = 0; i < cubesPrefab.Length; i++)
        {
            cubes[i] = Instantiate(cubesPrefab[i]) as GameObject;
        }

        shopParent = GameObject.FindGameObjectWithTag("Shop Cubes");
        cubes[0].transform.parent = shopParent.transform;
        cubes[1].transform.parent = shopParent.transform;
        cubes[2].transform.parent = shopParent.transform;
        cubes[3].transform.parent = shopParent.transform;
        cubes[4].transform.parent = shopParent.transform;
    }
}
