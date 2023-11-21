using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectDiamonds : MonoBehaviour
{

    public AudioClip collectDiamond;
    public Text diamonds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 1);
            GetComponent<AudioSource>().clip = collectDiamond;
            GetComponent<AudioSource>().Play();
            diamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();
        }
    }
}
