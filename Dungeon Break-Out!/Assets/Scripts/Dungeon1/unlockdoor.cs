using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockdoor : MonoBehaviour
{
    public static unlockdoor instance;
    private int num_items;
    public bool jail_opened;
    public bool canInteract;
    public bool hasKey;
    public Animator animator;
    public string itemName;
    public Collider triggerCollider;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (ItemSlotNumber(itemName) >= 0)
            {
                hasKey = true;
                UIController.instance.ActivateDialog("[Press 'E'] to open jail door");
            }
            else
            {
                UIController.instance.ActivateDialog("I need to find a key to open the jail door");
            }
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = false;
            UIController.instance.DeactivateDialog();

            if (jail_opened)
            {
                int num = ItemSlotNumber(itemName);
                Inventory.instance.allInventorySlotInfo[num].Name = null;
                Inventory.instance.allInventorySlotInfo[num].Icon = null;
                Inventory.instance.allInventorySlotInfo[num].Description = null;
                Destroy(triggerCollider);
            }
        }
    }

    void Update()
    {
        if (canInteract && InputManager.instance.ePressed && hasKey)
        {
            UIController.instance.DeactivateDialog();
            animator.SetTrigger("unlockdoor");
            Inventory.instance.RemoveItem(itemName);
            jail_opened = true;
            canInteract = false;
            hasKey = false;
            Hint.instance.keyUsed = true;
        }
    }

    int ItemSlotNumber(string item)
    {
        for (int i = 0; i < Inventory.instance.allInventorySlotInfo.Count; i++)
        {
            if (Inventory.instance.allInventorySlotInfo[i].Name == item)
            {
                return i;
            }
        }
        return -1;
    }
}
