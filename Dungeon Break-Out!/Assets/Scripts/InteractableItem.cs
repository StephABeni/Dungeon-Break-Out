using DuloGames.UI;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public UIItemInfo itemInfo;
    public bool canInteract;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        //AlternateTriggerEnter();
        if (InputManager.instance.ePressed && canInteract)
        {
            switch (itemInfo.ItemType)
            {
                case 1:
                    PickUp();
                    break;
                case 2:
                    Push();
                    break;
                default:
                    Debug.Log("You inspect " + itemInfo.Name);
                    break;
            }
        }
    }

    public void Push()
    {
        itemInfo.Pushed = !itemInfo.Pushed;
        Debug.Log("You pushed " + itemInfo.Pushed);
        //canInteract = false;
        UIController.instance.DeactivateDialog();
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
        if (other.tag == "Player")
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
