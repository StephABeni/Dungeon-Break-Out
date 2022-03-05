using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb_raise : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tomb_cube")
        {
            animator.SetTrigger("Tomb_raise");
            Debug.Log("Tomb raised!");
        }
    }

}
