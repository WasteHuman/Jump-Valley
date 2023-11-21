using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnim : MonoBehaviour
{
    private SpriteRenderer star;
    private float moveSpeed = 0.5f;

    private void Start()
    {
        star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        star.color = new Color(star.color.r, star.color.g, star.color.b, Mathf.PingPong(Time.time / 2.5f, 1.0f));

        //Move
        transform.position += transform.up * Time.deltaTime * moveSpeed;
    }
}
