using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNowCube : MonoBehaviour
{
    public GameObject mainCube;
    public GameObject whichCube;

    private void OnMouseDown()
    {
        if (PlayerPrefs.GetString(whichCube.GetComponent<SelectCube>().nowCube) == "Open")
        {
            mainCube.GetComponent<MeshRenderer>().material = GameObject.Find(whichCube.GetComponent<SelectCube>().nowCube).GetComponent<MeshRenderer>().material;
            PlayerPrefs.SetString("Now Cube", whichCube.GetComponent<SelectCube>().nowCube);
            GetComponent<AudioSource>().Play();
        }
    }
}
