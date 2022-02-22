using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLasers : MonoBehaviour
{
    public static EnableLasers instance;
    public bool lasersOn = false;
    public Inventory playerInventory;
    public GameObject laser;
    public GameObject blueLights;
    public GameObject electricity;
    public GameObject mirrors;
    public GameObject mirrorPad1;
    public GameObject mirrorPad2;
    public GameObject mirrorPad3;
    public GameObject dustFX;
    public Animator targetAnimator;
    public Animator largePortalAnimator;
    public Animator smallPortalAnimator;
    public Collider triggerCollider;
    public string itemName;
    public bool canInteract;
    public bool usedGem;
    public bool puzzleComplete = false;

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

    // Deactivate all puzzle components
    private void Start()
    {
        laser.SetActive(false);

        blueLights.SetActive(false);

        electricity.SetActive(false);

        mirrors.SetActive(false);

        mirrorPad1.GetComponent<SphereCollider>().enabled = false;
        mirrorPad2.GetComponent<SphereCollider>().enabled = false;
        mirrorPad3.GetComponent<SphereCollider>().enabled = false;

        dustFX.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            if (ItemSlotNumber(itemName) >= 0 && RunePuzzle.instance.puzzleComplete)
            {
                UIController.instance.ActivateDialog("[Press 'E'] to place Gem");
                canInteract = true;
            }
            else if (!RunePuzzle.instance.puzzleComplete)
            {
                UIController.instance.ActivateDialog("I need something to point the laser at.\nMaybe I should complete another puzzle");
            }
            else
            {
                UIController.instance.ActivateDialog("I need to find a Gem to power this device");
            }
            
        }
    }

    // turn off any UI pop ups
    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
        UIController.instance.DeactivateDialog();

        if (lasersOn)
        {
            int num = ItemSlotNumber(itemName);
            Inventory.instance.allInventorySlotInfo[num].Name = null;
            Inventory.instance.allInventorySlotInfo[num].Icon = null;
            Inventory.instance.allInventorySlotInfo[num].Description = null;
            Destroy(triggerCollider);
        }

    }

    void Update()
    {
        if (canInteract && InputManager.instance.ePressed && RunePuzzle.instance.puzzleComplete)
        {
            UIController.instance.DeactivateDialog();
            laser.SetActive(true);

            blueLights.SetActive(true);

            electricity.SetActive(true);

            mirrors.SetActive(true);

            mirrorPad1.GetComponent<SphereCollider>().enabled = true;
            mirrorPad2.GetComponent<SphereCollider>().enabled = true;
            mirrorPad3.GetComponent<SphereCollider>().enabled = true;

            lasersOn = true;
            usedGem = true;
            Inventory.instance.RemoveItem(itemName);
        }
    }

    // disable all components after puzzle has been completed
    public void DisableLasers()
    {
        puzzleComplete = true;
        GameManager.instance.EnableMovement(true);
        UIController.instance.DeactivateDialog();

        laser.SetActive(false);

        blueLights.SetActive(false);

        electricity.SetActive(false);

        mirrors.SetActive(false);

        this.GetComponent<SphereCollider>().enabled = false;

        mirrorPad1.GetComponent<SphereCollider>().enabled = false;
        mirrorPad2.GetComponent<SphereCollider>().enabled = false;
        mirrorPad3.GetComponent<SphereCollider>().enabled = false;

        targetAnimator.SetTrigger("hideTarget");
        dustFX.SetActive(true);
        largePortalAnimator.SetTrigger("openLargePortal");
        smallPortalAnimator.SetTrigger("openSmallPortal");
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
