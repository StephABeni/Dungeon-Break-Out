using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockBox : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            animator.SetTrigger("unlockBox");
            Debug.Log("Unlocked!!!!!!");
        }

    }
}