using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getKey : MonoBehaviour
{
    public static getKey instance;
    public bool keyObtained = false;
    public GameObject key;

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
        key = GameObject.Find("Key Pick Up");
        key.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (LightCandle.instance.candleLit)
            {
                key.SetActive(true);
            }
            else
            {
                Debug.Log("It's too dark to look here. Maybe light some candles");
            }
        }
    }
}
