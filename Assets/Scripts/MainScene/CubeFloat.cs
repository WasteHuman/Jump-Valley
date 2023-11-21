using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFloat : MonoBehaviour
{
    private float speed = 1f;
    private Vector3 target = new Vector3(0, -0.01f,0);
    public GameObject mainCube;

    private void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position == target && target.y != (-0.09f))
        {
            target.y = -0.09f;
        }
        else if(transform.position == target && target.y == (-0.09f))
        {
            target.y = -0.01f;
        }
    }
}
