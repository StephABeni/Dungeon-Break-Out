using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            InteractableItem collidedItem = other.gameObject.GetComponent<InteractableItem>();
            UIController.instance.ActivateDialog("[Press 'E'] Pick Up " + collidedItem.itemInfo.Name);
            collidedItem.canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            InteractableItem collidedItem = other.gameObject.GetComponent<InteractableItem>();
            collidedItem.canInteract = false;
            UIController.instance.DeactivateDialog();
        }
    }
}
