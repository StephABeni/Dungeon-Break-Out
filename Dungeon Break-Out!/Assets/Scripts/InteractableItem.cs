using DuloGames.UI;
using UnityEngine;

public class InteractableItem: MonoBehaviour {
    public Item item;
    public UIItemInfo itemInfo;
    public bool canInteract;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (InputManager.instance.ePressed && canInteract)
        {
            if (item.canPickUp) {
                PickUp();
            } else
            {
                Debug.Log("You inspect " + item.itemName);
            }
        }
    }

    public void PickUp()
    {
        Inventory.instance.AddItem(item, itemInfo);
        Destroy(gameObject);
        canInteract = false;
        UIController.instance.DeactivateDialog();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canInteract = true;
            UIController.instance.ActivateDialog("[Press 'E'] Pick Up " + item.itemName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = false;
            UIController.instance.DeactivateDialog();
        }
    }
}
