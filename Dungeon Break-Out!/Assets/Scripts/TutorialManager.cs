using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPopUp;
    public GameObject enterToContinue;
    public Text titleText;
    public Text descriptionText;
    int currentPopUp = 0;
    bool tutorialFinished = false;
    bool taskComplete = false;

    // Update is called once per frame
    void Update()
    {
        if (!tutorialFinished)
        {
            tutorialPopUp.SetActive(true);

            if (currentPopUp == 0) { //walk
                titleText.text = "How To: Walk";
                descriptionText.text = "You've found yourself in a strange dungeon! How you got here is anyone's guess..." +
                    "\n\n use the WASD keys to walk around and try and find a way out.";
                if (InputManager.instance.movementInput != Vector2.zero)
                    taskComplete = true;
            } 
            if (currentPopUp == 1) { // run
                if (CharacterAnimator.instance.snappedAnimation == 2f)
                    taskComplete = true;
            } 
            if (currentPopUp == 2) { // mouselook
                if (InputManager.instance.lookInput != Vector2.zero)
                    taskComplete = true;
            } 
            if (currentPopUp == 3) { //telekinesis mode
                if (InputManager.instance.rightMousePressed == true)
                    taskComplete = true;
            } 
            if (currentPopUp == 4) { //pick up object in tk
                if (GameObject.Find("Player").GetComponent<Telekinesis>().currentlyHeldObject != null)
                    taskComplete = true;
            }
            if (currentPopUp == 5) { //drop object in tk
                if (GameObject.Find("Player").GetComponent<Telekinesis>().currentlyHeldObject == null)
                    taskComplete = true;
            }
            if (currentPopUp == 6) {   //pick up inventory item
                if(Inventory.instance.allInventorySlotInfo[0] != null)
                    taskComplete = true;
            }

            EnterToContinue();
        } else {
            tutorialPopUp.SetActive(false);
        }
    }

    private void EnterToContinue()
    {
        enterToContinue.SetActive(taskComplete);
        if(taskComplete && InputManager.instance.enterPressed){
            taskComplete = false;
            currentPopUp++;
        }
    }
}
