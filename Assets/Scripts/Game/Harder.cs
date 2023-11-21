using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour
{
    public GameObject detect_clicks;
    private bool hard;

    void Update()
    {
        if (CubeJump.count_blocks > 0)
        {
            if (CubeJump.count_blocks % 7 == 0 && !hard)
            {
                print("Молодца, сложнее!");
                Camera.main.GetComponent<Animation>().Play("Harder");
                detect_clicks.transform.position = new Vector3(0.76f, 2.55f, -4f);
                detect_clicks.transform.eulerAngles = new Vector3(15f, -10f, 0f);
                hard = true;
            }
            else if ((CubeJump.count_blocks % 7) - 1 == 0 && hard)
            {
                hard = false;
                print("Ну ты и лох, легче");
                detect_clicks.transform.position = new Vector3(0f, 0f, -8f);
                detect_clicks.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Camera.main.GetComponent<Animation>().Play("Easer");
            }
        }
    }
}
