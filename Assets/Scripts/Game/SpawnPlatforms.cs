using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public GameObject platform, all_cubes, diamond;
    private GameObject platformInst;
    private Vector3 target;
    private float speed = 8f;
    private bool on_place;

    private void Start()
    {
        spawn_platforms();
    }

    private void Update()
    {
        if (platformInst.transform.position != target && !on_place)
        {
            platformInst.transform.rotation = Quaternion.Euler(0, 0, 0);
            platformInst.transform.position = Vector3.MoveTowards(platformInst.transform.position, target, Time.deltaTime * speed);
        }
        else if (platformInst.transform.position == target)
        {
            on_place = true;
        }

        if (CubeJump.jump && CubeJump.next_platform)
        {
            spawn_platforms();

            on_place = false;
        }
    }

    float RandScale()
    {
        float rand;
        if (Random.Range(0, 100) > 80)
        {
            rand = Random.Range(1.2f, 2f);
        }
        else
        {
            rand = Random.Range(1.2f, 1.5f);
        }
        return rand;
    }

    void spawn_platforms()
    {
        target = new Vector3(Random.Range(0.7f, 1.7f), -Random.Range(0.6f, 3.2f), -0.6f);
        platformInst = Instantiate(platform, new Vector3(5f, -6f, -0.6f), Quaternion.identity) as GameObject;
        platformInst.transform.localScale = new Vector3(RandScale(), platformInst.transform.localScale.y, platformInst.transform.localScale.z);
        platformInst.transform.parent = all_cubes.transform;

        if (CubeJump.count_blocks %8 == 0 && CubeJump.count_blocks != 0)
        {
            GameObject diamondInst = Instantiate(diamond, new Vector3(platformInst.transform.position.x, platformInst.transform.position.y + 0.5f, platformInst.transform.position.z), Quaternion.Euler(Camera.main.transform.eulerAngles)) as GameObject;
            diamondInst.transform.parent = platformInst.transform;
        }
    }
}
