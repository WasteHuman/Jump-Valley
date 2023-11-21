using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObj : MonoBehaviour
{
    public float speed = 5f, checkPos = 0;

    private RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (rect.offsetMin.y != checkPos)
        {
            rect.offsetMin += new Vector2(-rect.offsetMin.x, speed);
            rect.offsetMax += new Vector2(-rect.offsetMax.x, speed);
        }
    }
}
