using DuloGames.UI;
using UnityEngine;

public class InteractableItem: MonoBehaviour {
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
            if (itemInfo.ItemType == 1) {
                PickUp();
            } else
            {
                Debug.Log("You inspect " + itemInfo.Name);
            }
        }
    }

    public void PickUp()
    {
        Inventory.instance.AddItem(itemInfo);
        Destroy(gameObject);
        canInteract = false;
        UIController.instance.DeactivateDialog();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canInteract = true;
            UIController.instance.ActivateDialog("[Press 'E'] Pick Up " + itemInfo.Name);
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
