using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupGem : MonoBehaviour
{

    //public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CharacterAnimator.instance.animator.SetTrigger("pickup");   

        }
    }

}
