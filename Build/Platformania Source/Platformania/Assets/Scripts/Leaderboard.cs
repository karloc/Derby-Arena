using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text highScoreBroj;
    string highScoreKey = "HighScore";

    void Start()
    {
        highScoreBroj.text = PlayerPrefs.GetInt(highScoreKey,0).ToString();
    }

    public void NamjestiNaNula()
    {
        highScoreBroj.text = "0";
    }
}
