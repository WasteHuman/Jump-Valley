using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Sprite musicOn, musicOff, soundsOn, soundsOff;
    public GameObject music, sounds, shopBG, shopBttn, closeBttn;

    private void Start()
    {
        if (gameObject.name == "Settings")
        {
            if (PlayerPrefs.GetString("Sounds") == "off")
            {
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = soundsOff;
                Camera.main.GetComponent<AudioListener>().enabled = false;
            }
            if (PlayerPrefs.GetString("Music") == "off")
            {
                transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = musicOff;
                Camera.main.GetComponent<AudioSource>().mute = true;
            }
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Restart":
                SceneManager.LoadScene("Main");
                CubeJump.lose = false;
                if (PlayerPrefs.GetString("Music") == "off")
                {
                    Camera.main.GetComponent<AudioSource>().mute = true;
                }
                break;
            case "VK":
                Application.OpenURL("https://vk.com/wastemoon_games");
                break;
            case "Settings":
                transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
                transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);
                break;
            case "Sounds":
                if (PlayerPrefs.GetString("Sounds") == "off")
                {
                    sounds.GetComponent<SpriteRenderer>().sprite = soundsOn;
                    Camera.main.GetComponent<AudioListener>().enabled = true;
                    PlayerPrefs.SetString("Sounds", "on");
                }
                else
                {
                    sounds.GetComponent<SpriteRenderer>().sprite = soundsOff;
                    Camera.main.GetComponent<AudioListener>().enabled = false;
                    PlayerPrefs.SetString("Sounds", "off");
                }
                break;
            case "Music":
                if (PlayerPrefs.GetString("Music") == "off")
                {
                    music.GetComponent<SpriteRenderer>().sprite = musicOn;
                    Camera.main.GetComponent<AudioSource>().mute = false;
                    PlayerPrefs.SetString("Music", "on");
                }
                else
                {
                    music.GetComponent<SpriteRenderer>().sprite = musicOff;
                    Camera.main.GetComponent<AudioSource>().mute = true;
                    PlayerPrefs.SetString("Music", "off");
                }
                break;
            case "Shop":
                SceneManager.LoadScene("Shop");
                closeBttn.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case "Close shop":
                SceneManager.LoadScene("Main");
                shopBttn.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
        }
    }
}
