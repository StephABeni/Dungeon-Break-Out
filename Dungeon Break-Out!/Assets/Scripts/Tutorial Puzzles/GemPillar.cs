using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPillar : MonoBehaviour
{
    public bool canInteract;
    public bool successfulInteraction;
    public GameObject placedGem;
    public string itemName;
    public Collider triggerCollider;

    // Update is called once per frame
    void Update()
    {
        if (canInteract && InputManager.instance.ePressed) {
            for (int i = 0; i < Inventory.instance.allInventorySlotInfo.Count; i++) {
                if (Inventory.instance.allInventorySlotInfo[i].Name == itemName) {
                    successfulInteraction = true;
                    placedGem.SetActive(true);
                    Inventory.instance.RemoveItem(itemName);
                    Destroy(triggerCollider);
                    TutorialManager.instance.tutorialGemPlaced = true;
                    break;
                }
            }
            if (!successfulInteraction) {
                UIController.instance.ActivateDialog("Nothing happens...");
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            UIController.instance.ActivateDialog("[Press 'E'] Interact with pillar");
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            canInteract = false;
            UIController.instance.DeactivateDialog();
        }
    }
}
