using UnityEngine;

public class Shop : MonoBehaviour
{
    public Animation buttonsAnimUp;

    private void Awake()
    {
        if (PlayerPrefs.GetString("Sounds") == "Off")
        {
            Camera.main.GetComponent<AudioListener>().enabled = false;
        }
        if (PlayerPrefs.GetString("Music") == "Off")
        {
            Camera.main.GetComponent<AudioSource>().mute = true;
        }
    }

    void Start()
    {
        buttonsAnimUp.Play();

        if (PlayerPrefs.GetString("Cube 1") != "Open")
        {
            PlayerPrefs.SetString("Cube 1", "Open");
        }
    }
}
