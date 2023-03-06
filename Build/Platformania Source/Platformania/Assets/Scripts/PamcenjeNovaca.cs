using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PamcenjeNovaca : MonoBehaviour
{

    static int indexPosljednjeScene = 0;
    private int indexPocetneScene;

    private void Awake()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;

        if(indexPosljednjeScene == indexScene)
        {
            int brojNovaca = FindObjectsOfType<PamcenjeNovaca>().Length;
            if (brojNovaca > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            StartCoroutine(Singleton());
        }
    }

    IEnumerator Singleton()
    {
        yield return new WaitForSecondsRealtime(Time.deltaTime);

        int brojNovaca = FindObjectsOfType<PamcenjeNovaca>().Length;
        if (brojNovaca > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        indexPocetneScene = SceneManager.GetActiveScene().buildIndex;
        indexPosljednjeScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        CheckIfStillInSameScene();
    }

    private void CheckIfStillInSameScene()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        if (indexScene != indexPocetneScene)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
