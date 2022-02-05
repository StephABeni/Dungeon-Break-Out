using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockBox : MonoBehaviour
{
    public static unlockBox instance;
    public bool boxOpened = false;
    public Animator animator;
    public GameObject matches;

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

    private void Start()
    {
        matches = GameObject.Find("Matches Pick Up");
        matches.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("unlockBox");
            boxOpened = true;
            matches.SetActive(true);
        }
    }
}
