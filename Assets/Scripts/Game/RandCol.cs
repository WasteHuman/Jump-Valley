using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandCol : MonoBehaviour
{
    public Color[] colors;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
    }
}
