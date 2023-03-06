using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    static int brojZivota = 5;
    static int kolicinaNovaca = 0;
    static int highScoreBroj = 0;
    
    private int zivot = 0;

    [SerializeField] Text textZaZivot;
    [SerializeField] Text textZaNovac;
    string highScoreKey = "HighScore";
    
    private void Awake()
    {
        int brojPokrenutihSesija = FindObjectsOfType<GameController>().Length;

        if(brojPokrenutihSesija > 1)
        {
            Destroy(gameObject);
        }else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        brojZivota = 5;
        kolicinaNovaca = 0;
        textZaZivot.text = brojZivota.ToString();
        textZaNovac.text = kolicinaNovaca.ToString();
        highScoreBroj = PlayerPrefs.GetInt(highScoreKey,0);
        zivot = PlayerPrefs.GetInt("zivot");
    }

    public void PovecajNovac(int novac)
    {
        kolicinaNovaca += novac;
        textZaNovac.text = kolicinaNovaca.ToString();

        if(kolicinaNovaca > highScoreBroj)
        {
            PlayerPrefs.SetInt(highScoreKey,kolicinaNovaca);
            PlayerPrefs.Save();
        }
    }

    
    public void Smrt()
    {
        if (brojZivota >= 1)
        {
            OduzmiZivot();
        }else
        {
            RestartajSesiju();
        }
    }

    private void OduzmiZivot()
    {
        brojZivota--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        textZaZivot.text = brojZivota.ToString();
        zivot++;
        PlayerPrefs.SetInt("zivot",zivot);
    }

    public void RestartajSesiju()
    {
        SceneManager.LoadScene("Main Menu");
        Destroy(gameObject);
    }

    public void ResetajStatse()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("neprijatelji");
        PlayerPrefs.DeleteKey("strijela");
        PlayerPrefs.DeleteKey("zivot");
    }
}
