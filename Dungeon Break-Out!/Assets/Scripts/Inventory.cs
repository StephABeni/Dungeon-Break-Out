using System.Collections;
using DuloGames.UI;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private List<Item> itemlist;
    public List<UIItemSlot> allInventorySlots;
    public List<UIItemInfo> allInventorySlotInfo = new List<UIItemInfo>();

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

    // Start is called before the first frame update
    void Start()
    {
        itemlist = new List<Item>();
    }

    public void AddItem(Item item, UIItemInfo itemInfo)
    {
        itemlist.Add(item);
        Debug.Log("Added " + item.itemName + " to inventory");
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

    public void UpdateSlotInfo()
    {
        allInventorySlotInfo.Clear();

        foreach (UIItemSlot itemSlot in allInventorySlots)
            allInventorySlotInfo.Add(itemSlot.GetItemInfo());
    }
}
