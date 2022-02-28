using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySounds : MonoBehaviour
{
    public bool matchesPickedUp;
    public bool keysPickedUp;
    public bool gemPickedUp;
    public Inventory playerInventory;
    public GameObject matches;
    public GameObject keys;
    public GameObject gem;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!matchesPickedUp && ItemSlotNumber("Matches") >= 0)
        {
            matches.GetComponent<AudioSource>().Play();
            matchesPickedUp = true;
        }
        if (!keysPickedUp && ItemSlotNumber("Iron Key") >= 0)
        {
            keys.GetComponent<AudioSource>().Play();
            keysPickedUp = true;
        }
        if (!gemPickedUp && ItemSlotNumber("Gem") >= 0)
        {
            gem.GetComponent<AudioSource>().Play();
            gemPickedUp = true;
        }

        if (matchesPickedUp && keysPickedUp && gemPickedUp)
        {
            Destroy(this);
        }
    }

    int ItemSlotNumber(string item)
    {
        for (int i = 0; i < playerInventory.allInventorySlotInfo.Count; i++)
        {
            if (playerInventory.allInventorySlotInfo[i] != null)
            {

                if (playerInventory.allInventorySlotInfo[i].Name == item)
                {
                    return i;
                }
            }
        }
        return -1;
    }
}
