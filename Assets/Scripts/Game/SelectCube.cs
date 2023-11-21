using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCube : MonoBehaviour
{
    [HideInInspector]
    public string nowCube;

    public GameObject selectCube, buyCube, cost;

    private void Start()
    {
        //PlayerPrefs.DeleteKey("Diamonds");
        //PlayerPrefs.SetInt("Diamonds", 500);
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetString("Cube 1") != "Open")
        {
            PlayerPrefs.SetString("Cube 1", "Open");
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetString(nowCube) == "Open")
        {
            selectCube.SetActive(true);
            buyCube.SetActive(false);
        }
        else
        {
            selectCube.SetActive(false);
            buyCube.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        nowCube = other.gameObject.name;
        other.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);

        if (PlayerPrefs.GetString(nowCube) == "Open")
        {
            selectCube.SetActive(true);
            buyCube.SetActive(false);
            cost.SetActive(false);
        }
        else
        {
            selectCube.SetActive(false);
            buyCube.SetActive(true);
            cost.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
