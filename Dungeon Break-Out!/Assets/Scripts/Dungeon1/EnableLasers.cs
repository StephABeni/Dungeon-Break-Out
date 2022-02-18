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

            if (lasersOn)
            {
                return;
            }

            playerInventory = Inventory.instance;

            // loop through player inventory to find Gem
            for (int i = 0; i < 20; i++)
            {
                if (playerInventory.allInventorySlotInfo[i].Name == "Gem")
                {
                    if (RunePuzzle.instance.puzzleComplete)
                    {
                        // activate puzzle components
                        laser.SetActive(true);

                        blueLights.SetActive(true);

                        electricity.SetActive(true);

                        mirrors.SetActive(true);

                        mirrorPad1.GetComponent<SphereCollider>().enabled = true;
                        mirrorPad2.GetComponent<SphereCollider>().enabled = true;
                        mirrorPad3.GetComponent<SphereCollider>().enabled = true;

                        lasersOn = true;

                        playerInventory.allInventorySlotInfo[i].Name = null;
                        playerInventory.allInventorySlotInfo[i].Description = null;
                        playerInventory.allInventorySlotInfo[i].Icon = null;
                        playerInventory.allInventorySlotInfo[i].ItemType = 0;
                        Debug.Log("Lasers on. Removed Gem from player inventory.");
                        break;
                    } else
                    {
                        // if player hasn't completed the rune puzzle
                        UIController.instance.ActivateDialog("I need something to point the laser at.\nMaybe I should complete another puzzle");
                    }
                }
            }

            if (!lasersOn)
            {
                // if player hasn't obtained gem
                UIController.instance.ActivateDialog("Looks like I need a powerful stone to power this thing");
            }
        }
    }

    // turn off any UI pop ups
    private void OnTriggerExit(Collider other)
    {
        UIController.instance.DeactivateDialog();
    }

    // disable all components after puzzle has been completed
    public void DisableLasers()
    {
        
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
}
