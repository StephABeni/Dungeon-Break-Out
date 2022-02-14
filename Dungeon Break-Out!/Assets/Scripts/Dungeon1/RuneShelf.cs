using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneShelf : MonoBehaviour
{
    public static RuneShelf instance;
    public string correctRune;
    public bool correct = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == correctRune)
        {
            correct = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (correct)
        {
            correct = false;
        }
    }
}
