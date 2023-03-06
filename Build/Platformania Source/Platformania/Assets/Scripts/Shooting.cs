using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject arrow;
    public Vector2 velocity;
    public Vector2 offset = new Vector2(0.4f,-0.2f);
    public float cooldown = 0.5f;
    bool puca = true;

    private int strijela = 0;

    void Start()
    {
        strijela = PlayerPrefs.GetInt("strijela");
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if(Input.GetMouseButtonDown(0) && puca)
        {
            strijela++;
            PlayerPrefs.SetInt("strijela",strijela);

            GameObject objekt = (GameObject) Instantiate(arrow, new Vector2 (transform.position.x + offset.x*transform.localScale.x, transform.position.y + offset.y), Quaternion.identity);

            if(gameObject.transform.localScale.x == -1)
            {
                objekt.transform.localScale = new Vector3(-5,5,0);
            }

            objekt.GetComponent<Rigidbody2D>().velocity = new Vector2 (velocity.x * transform.localScale.x, velocity.y);
            StartCoroutine(Pucanje());
            GetComponent<Animator>().SetTrigger ("Fire");
        }
        }
    }

    IEnumerator Pucanje()
    {
        puca = false;
        yield return new WaitForSeconds(cooldown);
        puca = true;
    }
}
