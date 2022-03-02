using DuloGames.UI;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [Header("Object Information")]
    public UIItemInfo itemInfo;
    public bool canInteract;
    public string dialogText;
    public GameObject replacingObject;
    public string keyName;
    public bool successfulInteraction;

    private void Awake()
    {
        if (dialogText == "")   //if not custom set in inspector
        {
            if (itemInfo.ItemType == 1) dialogText = "[Press 'E'] Pick Up ";
            if (itemInfo.ItemType == 5) dialogText = "[Press 'E'] Open ";
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (canInteract && InputManager.instance.ePressed)
        {
            switch (itemInfo.ItemType)
            {
                case 1:
                    PickUp();
                    break;
                case 2:
                    Push();
                    break;
                case 3:
                    Break();
                    break;
                case 4:
                    Bone();
                    break;
                case 5:
                    Open();
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
        canInteract = false;
        UIController.instance.DeactivateDialog();
    }

    public void Break()
    {
        replacingObject.SetActive(true);
        gameObject.SetActive(false);
        canInteract = false;
        UIController.instance.DeactivateDialog();
    }

    public void Bone()
    {

        for (int i = 0; i < Inventory.instance.allInventorySlotInfo.Count; i++)
         {
            if (Inventory.instance.allInventorySlotInfo[i] != null
                && Inventory.instance.allInventorySlotInfo[i].Name == "hammer")
            {
                replacingObject.SetActive(true);
                gameObject.SetActive(false);
                canInteract = false;
                UIController.instance.DeactivateDialog();
                break;
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

    public void Open()
    {
        for (int i = 0; i < Inventory.instance.allInventorySlotInfo.Count; i++) {
            if (Inventory.instance.allInventorySlotInfo[i] != null
                && Inventory.instance.allInventorySlotInfo[i].Name == keyName) {
                successfulInteraction = true;
                UIController.instance.DeactivateDialog();
                break;
            }
        }
        if (!successfulInteraction) {
            UIController.instance.ActivateDialog(itemInfo.Name + " won't open... ");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (itemInfo.ItemType == 5 && successfulInteraction) return;
            UIController.instance.ActivateDialog(dialogText + itemInfo.Name);
            canInteract = true;
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
