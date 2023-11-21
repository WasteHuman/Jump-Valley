using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameArrangement : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject buttons, mainCube, spawn_platforms, diamonds, music;

    public Light dirLight, dirLight_2;

    public Animation cubes_anim, block;
    public Animation buttonsAnimUp, gameNameAnimDown;
    public Animation gameNameAnimUp, buttonsAnimDown;

    public Text playTxt, gameName, study, record;

    private Vector3 target;
    private Quaternion rot_target;

    private float speed, rot_speed;

    private bool clicked;

    private void Awake()
    {

    }
    private void Start()
    {
        target = new Vector3(-10.69f, 15.65f, -6.93f);
        rot_target = Quaternion.Euler(42.8f, 26.071f, 63.696f);
        speed = 5f;
        rot_speed = 80f;

        buttonsAnimUp.Play();
        gameNameAnimDown.Play();
    }

    private void Update()
    {
        if (clicked && dirLight.intensity != 0)
        {
            dirLight.intensity -= 0.03f;
        }
        if (clicked && dirLight_2.intensity >= 1.05f)
        {
            dirLight_2.intensity -= 0.025f;
        }
        if (clicked) // Поворот света
        {
            dirLight.transform.position = Vector3.MoveTowards(dirLight.transform.position, target, Time.deltaTime * speed);
            dirLight.transform.rotation = Quaternion.RotateTowards(dirLight.transform.rotation, rot_target, Time.deltaTime * rot_speed);
            dirLight_2.transform.position = Vector3.MoveTowards(dirLight_2.transform.position, target, Time.deltaTime * speed);
            dirLight_2.transform.rotation = Quaternion.RotateTowards(dirLight_2.transform.rotation, rot_target, Time.deltaTime * rot_speed);

            Camera.main.GetComponent<AudioSource>().volume = 0.25f;
        }
    }

    private void OnMouseDown()
    {
        if (!clicked)
        {
            StartCoroutine(delCubes());
            clicked = true; // Работает только один раз
            playTxt.gameObject.SetActive(false);
            study.gameObject.SetActive(true);
            record.gameObject.SetActive(true);
            diamonds.SetActive(true);

            if (music.activeSelf)
            {
                music.gameObject.transform.parent.transform.GetChild(0).gameObject.SetActive(!music.gameObject.transform.parent.transform.GetChild(0).gameObject.activeSelf);
            }

            gameName.text = "0";
            buttonsAnimDown.Play("ButtonsAnimationDown");

            buttons.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            buttons.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

            mainCube.GetComponent<Animation>().Play("StartGameCube");
            StartCoroutine(cubeToPlatform());
            mainCube.transform.localScale = new Vector3(1f,1f,1f);
            cubes_anim.Play();
        }
        else if (clicked && study.gameObject.activeSelf)
        {
            study.gameObject.SetActive(false);
        }
    }

    IEnumerator delCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.3f);
            cubes[i].GetComponent<FallCube>().enabled = true;
        }
        spawn_platforms.GetComponent<SpawnPlatforms>().enabled = true;
    }

    IEnumerator cubeToPlatform()
    {
        yield return new WaitForSeconds(mainCube.GetComponent<Animation>().clip.length);
        block.Play();

        mainCube.AddComponent<Rigidbody>();
    }
}
