using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceControl : MonoBehaviour
{
    public AudioSource hey;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hey = GetComponent<AudioSource>();
            hey.Play();
        }
    }
}