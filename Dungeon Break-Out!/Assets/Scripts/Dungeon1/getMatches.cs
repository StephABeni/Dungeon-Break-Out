using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMatches : MonoBehaviour
{
    public static getMatches instance;
    public bool matchesObtained = false;

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
            if (unlockBox.instance.boxOpened)
            {
                GameObject.Find("Matches Pick Up").SetActive(true);
            }
            else
            {
                Debug.Log("Open box before obtaining matches");
            }
        }
    }
}
