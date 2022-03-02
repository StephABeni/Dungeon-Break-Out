using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneShelf : MonoBehaviour
{
    public static RuneShelf instance;
    public string correctRune;
    public bool correct = false;

    private void Awake()
    {
        this.GetComponentInChildren<ParticleSystem>().Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == correctRune)
        {
            this.GetComponentInChildren<ParticleSystem>().Play();
            correct = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (correct)
        {
            this.GetComponentInChildren<ParticleSystem>().Stop();
            correct = false;
        }
    }
}
