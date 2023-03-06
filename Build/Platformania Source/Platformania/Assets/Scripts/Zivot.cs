using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zivot : MonoBehaviour
{
    [SerializeField] float hp = 100f;

    
    private int neprijatelji = 0;

    void Start()
    {
        neprijatelji = PlayerPrefs.GetInt("neprijatelji");
    }

    public void NapraviStetu(float steta)
    {
        hp -= steta;
        if(hp <= 0)
        {
            PlayerPrefs.SetInt("neprijatelji",PlayerPrefs.GetInt("neprijatelji")+1);
            Destroy(gameObject);
        }
    }
}
