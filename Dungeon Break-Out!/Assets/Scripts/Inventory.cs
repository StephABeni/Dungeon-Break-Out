using System.Collections;
using DuloGames.UI;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<UIItemSlot> allInventorySlots;
    public List<UIItemInfo> allInventorySlotInfo = new List<UIItemInfo>(20);

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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

    public void AddItem(UIItemInfo itemInfo)
    {
        allInventorySlotInfo.Add(itemInfo);
        Debug.Log("Added " + itemInfo.Name + " to inventory");
        for (int i = 0; i < allInventorySlots.Count; i++)
        {
            if (!allInventorySlots[i].IsAssigned())
            {
                allInventorySlots[i].Assign(itemInfo);
                UpdateSlotInfo();
                break;
            }
        }
    }

    public void RemoveItem(string itemName) {
        for (int i = 0; i < allInventorySlotInfo.Count; i++) {
            if (allInventorySlotInfo[i].Name == itemName) {
                allInventorySlots[i].Unassign();
                break;
            }
        }
    }

    public void UpdateSlotInfo()
    {
        allInventorySlotInfo.Clear();

        foreach (UIItemSlot itemSlot in allInventorySlots)
            allInventorySlotInfo.Add(itemSlot.GetItemInfo());
    }

    public bool HasItem(string itemName) {
        for (int i = 0; i < allInventorySlotInfo.Count; i++) {
            if (allInventorySlotInfo[i] != null
                && allInventorySlotInfo[i].Name == itemName) {
                return true;
            }
        }
        return false;
    }
}
