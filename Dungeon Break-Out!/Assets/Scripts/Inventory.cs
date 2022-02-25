using System.Collections;
using DuloGames.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public GameObject tutorialPopUp; // tutorial pop up
    public GameObject enterToContinue; // enter
    public Text titleText; // Title
    public Text descriptionText; // instructions


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

    public void DoubleClick()
    {
        TutorialManager.instance.currentStage = 20;
        //tutorialPopUp.SetActive(true);
        //titleText.text = "Drakes";
        //descriptionText.text = "You've found yourself in a strange dungeon! How you got here is anyone's guess..." +
        //    "\n\nUse the WASD keys to walk around and try and find a way out.";
        Debug.Log("HEY");
        //EnterToContinue();
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

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < allInventorySlotInfo.Count; i++)
        {
            if (allInventorySlotInfo[i].Name == itemName)
            {
                allInventorySlots[i].Unassign();
                break;
            }
        }
    }

    private void EnterToContinue()
    {
        //enterToContinue.SetActive(true);
        if (InputManager.instance.enterPressed)
        {
            tutorialPopUp.SetActive(false);
        }
    }

    public void UpdateSlotInfo()
    {
        allInventorySlotInfo.Clear();

        foreach (UIItemSlot itemSlot in allInventorySlots)
            allInventorySlotInfo.Add(itemSlot.GetItemInfo());
    }
}
