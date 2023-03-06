using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{

    private Audio music;
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    void Start()
    {
        music = GameObject.FindObjectOfType<Audio>();
        UpdateIkonaIVolumen();
    }

    public void PauseMusic()
    {
        music.ToggleSound();
        UpdateIkonaIVolumen();
    }

    void UpdateIkonaIVolumen()
    {
        if (PlayerPrefs.GetInt("Muted",0) == 0)
        {
            AudioListener.volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
        }
    }
}
