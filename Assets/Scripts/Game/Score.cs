using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text record;
    private Text txt;
    private bool game_start;

    private void Start()
    {
        record.text = "Top: " + PlayerPrefs.GetInt("Record").ToString();
        txt = GetComponent<Text>();
        CubeJump.count_blocks = 0;
    }

    private void Update()
    {
        if (txt.text == "0")
        {
            game_start = true;
        }
        if (game_start)
        {
            txt.text = CubeJump.count_blocks.ToString();
            if (PlayerPrefs.GetInt("Record") < CubeJump.count_blocks)
            {
                PlayerPrefs.SetInt("Record", CubeJump.count_blocks);
                record.text = "Top: " + PlayerPrefs.GetInt("Record").ToString();
            }
        }
    }
}
