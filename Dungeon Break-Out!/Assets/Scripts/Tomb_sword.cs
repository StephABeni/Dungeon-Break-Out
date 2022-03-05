using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb_sword : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tomb_sword")
        {
            animator.SetTrigger("Tomb_sword");
            Debug.Log("Tomb raised!");
        }
    }

}
