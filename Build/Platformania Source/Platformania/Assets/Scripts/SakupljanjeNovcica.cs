using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakupljanjeNovcica : MonoBehaviour
{

    [SerializeField] int kolicinaNovaca = 10;
    [SerializeField] AudioClip zvukSakupljanja;
    private bool collected = false;


    private void OnTriggerEnter2D(Collider2D col)
    {
        var igrac = col.GetComponent<Player>();
        if(igrac && collected == false)
        {
                collected = true;
                FindObjectOfType<GameController>().PovecajNovac(kolicinaNovaca);
                AudioSource.PlayClipAtPoint(zvukSakupljanja, Camera.main.transform.position);
                Destroy(gameObject);
        }
    }
}
