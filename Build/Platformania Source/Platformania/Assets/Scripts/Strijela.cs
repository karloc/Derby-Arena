using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strijela : MonoBehaviour
{
    [SerializeField] float steta = 50;
    CapsuleCollider2D bodyCollider;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var hp = col.GetComponent<Zivot>();
        var protivnik = col.GetComponent<EnemyMovement>();
        var unistiStrijelu = col.GetComponent<UnistiStrijelu>();

        if(protivnik && hp)
        {
            hp.NapraviStetu(steta);
            Destroy(gameObject);
        } 

        if(unistiStrijelu)
        {
            Destroy(gameObject);
        }
    }
}
