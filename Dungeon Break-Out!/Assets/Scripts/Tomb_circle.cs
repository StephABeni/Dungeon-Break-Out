using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb_circle : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tomb_circle")
        {
            animator.SetTrigger("Tomb_circle");
            Debug.Log("Tomb raised!");
        }
    }

}

