using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLasers : MonoBehaviour
{
    public static EnableLasers instance;
    public bool lasersOn = false;
    public Inventory playerInventory;
    public GameObject laser;
    public GameObject blueLights;
    public GameObject electricity;
    public GameObject mirrors;
    public GameObject mirrorPad1;
    public GameObject mirrorPad2;
    public GameObject mirrorPad3;

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
        laser = GameObject.Find("Laser Pointer");
        laser.SetActive(false);

        blueLights = GameObject.Find("Electricity Lights");
        blueLights.SetActive(false);

        electricity = GameObject.Find("Laser Electricity");
        electricity.SetActive(false);

        mirrors = GameObject.Find("Mirrors");
        mirrors.SetActive(false);

        mirrorPad1 = GameObject.Find("SM_Env_Tiles_Rune_01 (1)");
        mirrorPad1.GetComponent<SphereCollider>().enabled = false;
        mirrorPad2 = GameObject.Find("SM_Env_Tiles_Rune_01 (2)");
        mirrorPad2.GetComponent<SphereCollider>().enabled = false;
        mirrorPad3 = GameObject.Find("SM_Env_Tiles_Rune_01 (3)");
        mirrorPad3.GetComponent<SphereCollider>().enabled = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (lasersOn)
            {
                return;
            }

            playerInventory = Inventory.instance;

            for (int i = 0; i < 20; i++)
            {
                if (playerInventory.allInventorySlotInfo[i].Name == "Gem")
                {
                    Debug.Log("Trying to light lasers");

                    laser.SetActive(true);

                    blueLights.SetActive(true);

                    electricity.SetActive(true);

                    mirrors.SetActive(true);

                    mirrorPad1.GetComponent<SphereCollider>().enabled = true;
                    mirrorPad2.GetComponent<SphereCollider>().enabled = true;
                    mirrorPad3.GetComponent<SphereCollider>().enabled = true;

                    lasersOn = true;

                    playerInventory.allInventorySlotInfo[i].Name = null;
                    playerInventory.allInventorySlotInfo[i].Description = null;
                    playerInventory.allInventorySlotInfo[i].Icon = null;
                    playerInventory.allInventorySlotInfo[i].ItemType = 0;
                    Debug.Log("Lasers on. Removed Gem from player inventory.");
                    break;
                }
            }
            if (!lasersOn)
            {
                Debug.Log("Pick up Gem to see what happens");
            }
        }
    }
}
