using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockBox : MonoBehaviour
{
    public static unlockBox instance;
    public bool boxOpened = false;
    public Animator animator;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple Inventory Instances.");
                Destroy(this);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("unlockBox");
            boxOpened = true;
            Debug.Log("Box opened. Add matches to player inventory.");
        }
    }
}
