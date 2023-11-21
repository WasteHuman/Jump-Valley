using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{
    public GameObject whichCube, selectBttn, mainCube, cost;
    public AudioClip openCube;

    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("Diamonds") >= 20)
        {
            PlayerPrefs.SetString(whichCube.GetComponent<SelectCube>().nowCube, "Open");
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") - 20);
            PlayerPrefs.SetString("Now Cube", whichCube.GetComponent<SelectCube>().nowCube);
            mainCube.GetComponent<MeshRenderer>().material = GameObject.Find(whichCube.GetComponent<SelectCube>().nowCube).GetComponent<MeshRenderer>().material;
            cost.SetActive(false);
            selectBttn.SetActive(true);
            gameObject.SetActive(false);
            GetComponent<AudioSource>().clip = openCube;
            GetComponentInParent<AudioSource>().Play();
        }
    }
}
