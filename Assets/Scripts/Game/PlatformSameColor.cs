using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSameColor : MonoBehaviour
{
    public AudioClip cubeDrop;
    public static bool firstOne;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube" && firstOne)
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
            GetComponent<AudioSource>().clip = cubeDrop;
            GetComponent<AudioSource>().Play();
        }
        if (!firstOne)
        {
            firstOne = true;
        }
    }
}
