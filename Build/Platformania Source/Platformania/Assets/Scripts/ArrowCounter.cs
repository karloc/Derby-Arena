using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowCounter : MonoBehaviour
{
    public Text strijela;

    void Update()
    {
        strijela.text = PlayerPrefs.GetInt("strijela").ToString();
    }
}
