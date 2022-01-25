using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockdoor : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("unlockdoor");
            Debug.Log("Jail opened.");
        }
    }
}
