using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MyTargetAds
{
    public static int count_blocks;
    public static bool jump, next_platform, animate, lose;
    public GameObject mainCube, buttons, lose_buttons;

    private float scratch_speed = 0.5f, startTime, yPosCube;
    private bool funcDone;
    private int advCount;

    private void Start()
    {
        StartCoroutine(CanJump());
        next_platform = false;
        jump = false;
        animate = false;
        funcDone = false;
        PlatformSameColor.firstOne = false;
    }

    private void FixedUpdate()
    {
        if (animate && mainCube.transform.localScale.y > 0.4f && mainCube != null)
        {
            PressCube(-scratch_speed);
        }
        else if (!animate && mainCube != null)
        {
            if (mainCube.transform.localScale.y < 1f)
            {
                PressCube(scratch_speed * 3f);
            }
            else if (mainCube.transform.localScale.y != 1f)
            {
                mainCube.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        if (mainCube != null)
        {
            if (mainCube.transform.position.y < -5f)
            {
                Destroy(mainCube);
                lose = true;
            }
        }

        if (lose && !funcDone)
        {
            PlayerLose();
        }
    }

    void PlayerLose()
    {
        funcDone = true;
        buttons.GetComponent<Animation>().Play("ButtonsAnimationUp");

        AudioManager.Audio.PlayLoseClip();

        if (!lose_buttons.activeSelf)
        {
            lose_buttons.SetActive(true);
        }
        lose_buttons.GetComponent<Animation>().Play("LoseButtonsAnimationUp");

        advCount++;
        if (advCount % 6 == 0)
        {
            YandexAds.instance.ShowAd();
        }
    }

    private void OnMouseDown()
    {
        if (next_platform && mainCube.GetComponent<Rigidbody>())
        {
            animate = true;
            startTime = Time.time;

            yPosCube = mainCube.transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        if (next_platform && mainCube.GetComponent<Rigidbody>())
        {
            animate = false;

            //Прыжок
            jump = true;
            float force, diff;
            diff = Time.time - startTime;

            if (diff < 3f)
            {
                force = 190 * diff;
            }
            else
            {
                force = 300f;
            }
            if (force < 60f)
            {
                force = 60f;
            }

            mainCube.GetComponent<Rigidbody>().AddForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * -force);

            StartCoroutine(checkCubePos());
            next_platform = false;
        }
    }

    void PressCube(float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, force * 3f * Time.deltaTime, 0f);
    }

    IEnumerator checkCubePos()
    {
        yield return new WaitForSeconds(1.5f);

        if (Mathf.Abs(yPosCube - mainCube.transform.localPosition.y) < 0.5f)
        {
            //Ты проиграл
            lose = true;
        }
        else
        {
            while (!mainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                yield return new WaitForSeconds(0.05f);
                if (mainCube == null)
                {
                    break;
                }
            }  
        }

        if (!lose)
        {
            //Следующая платформа
            next_platform = true;
            count_blocks++;
            mainCube.transform.localPosition = new Vector3(-0.3f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z);
            mainCube.transform.eulerAngles = new Vector3(0f, mainCube.transform.eulerAngles.y, 0f);
        }
    }

    IEnumerator CanJump()
    {
        while (!mainCube.GetComponent<Rigidbody>())
        {
            yield return new WaitForSeconds(0.05f);
        }
        //yield return new WaitForSeconds(1f);
        next_platform = true;
    }
}
