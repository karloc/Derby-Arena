using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZivotCounter : MonoBehaviour
{
    public Text zivot;

    void Update()
    {
        zivot.text = PlayerPrefs.GetInt("zivot").ToString();
    }
}
