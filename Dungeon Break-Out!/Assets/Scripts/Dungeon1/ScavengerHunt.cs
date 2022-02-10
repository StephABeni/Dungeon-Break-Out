using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavengerHunt : MonoBehaviour
{
    public static ScavengerHunt instance;
    private Inventory playerInventory;
    private List<string> playerInventoryItems;

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

    // returns players current inventory
    public Inventory GetPlayerInventory()
    {
        playerInventory = Inventory.instance;
        return playerInventory;
    }

    // returns players current inventory items count
    public int GetCurrentInventoryCount(Inventory currentInventory)
    {
        int count = 0;

        for (int i = 0; i < 20; i++)
        {
            if (currentInventory.allInventorySlotInfo[i].Name != "")
            {
                count++;
            }
        }
        return count;
    }

    // adds to list of current items players have
    public List<string> GetCurrentItems()
    {
        for (int i = 0; i < 20; i++)
        {
            Debug.Log(GetPlayerInventory().allInventorySlotInfo[i].Name != "");
            if (GetPlayerInventory().allInventorySlotInfo[i].Name != "")
            {
                playerInventoryItems.Add(GetPlayerInventory().allInventorySlotInfo[i].Name);
            }
        }
        return playerInventoryItems;
    }
}
