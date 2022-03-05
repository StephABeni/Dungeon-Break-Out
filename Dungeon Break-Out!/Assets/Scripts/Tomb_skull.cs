using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb_skull : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tomb_skull")
        {
            animator.SetTrigger("Tomb_skull");
            Debug.Log("Tomb raised!");
        }
    }

}
