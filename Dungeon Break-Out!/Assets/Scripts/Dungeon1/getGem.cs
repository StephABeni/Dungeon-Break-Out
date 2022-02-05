using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getGem : MonoBehaviour
{
    public static getGem instance;
    public bool gemObtained = false;
    public GameObject gem;

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
        gem = GameObject.Find("Gem Pick Up");
        gem.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (unlockdoor.instance.jail_opened)
            {
                gem.SetActive(true);
            }
        }
    }
}
