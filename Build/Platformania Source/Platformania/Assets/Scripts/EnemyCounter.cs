using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Text neprijatelji;

    void Update()
    {
        neprijatelji.text = PlayerPrefs.GetInt("neprijatelji").ToString();
    }
}