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
    int currentStage = 0;
    bool tutorialFinished = false;
    bool taskComplete = false;

    // Update is called once per frame
    void Update()
    {
        if (!tutorialFinished)
        {
            tutorialPopUp.SetActive(true);

            if (currentStage == 0) { //walk
                titleText.text = "How To: Walk";
                descriptionText.text = "You've found yourself in a strange dungeon! How you got here is anyone's guess..." +
                    "\n\nUse the WASD keys to walk around and try and find a way out.";
                if (InputManager.instance.movementInput != Vector2.zero)
                    taskComplete = true;
            } 
            if (currentStage == 1) { // run
                titleText.text = "How To: Run";
                descriptionText.text = "Perhaps you should move with a bit more urgency?" +
                    "\n\nPress 'Shift' while walking to run";
                if (CharacterAnimator.instance.snappedAnimation == 2f)
                    taskComplete = true;
            } 
            if (currentStage == 2) { // mouselook
                titleText.text = "How To: Look Around";
                descriptionText.text = "It's important to take in your surroundings when trying to find a way out." +
                    "\n\n Move the mouse to look in different directions. " +
                    "\nIf you move the mouse while walking, you will move relative to the direction you're looking.";
                if (InputManager.instance.lookInput != Vector2.zero)
                    taskComplete = true;
            } 
            if (currentStage == 3) { //telekinesis mode
                titleText.text = "How To: Move Objects (1/3)";
                descriptionText.text = "Sometimes to progress, you will need to move an object somewhere else." +
                    "\n\nClick the right mouse button to concentrate! ";
                if (InputManager.instance.rightMousePressed == true)
                    taskComplete = true;
            } 
            if (currentStage == 4) { //pick up object in tk
                titleText.text = "How To: Move Objects (2/3)";
                descriptionText.text = "While concentrating, look at a nearby object (for example, the golden cube)." +
                    "\n\nIf it sparkles, you can press 'E' to lift it up!";
                if (GameObject.Find("Player").GetComponent<Telekinesis>().currentlyHeldObject != null)
                    taskComplete = true;
            }
            if (currentStage == 5) { //drop object in tk
                titleText.text = "How To: Move Objects (3/3)";
                descriptionText.text = "You can move while holding this object, but you probably don't want to hang onto it forever, right?" +
                    "\n\nPress 'E' again to drop the item, or break your concentration by clicking the right mouse button again.";
                if (GameObject.Find("Player").GetComponent<Telekinesis>().currentlyHeldObject == null)
                    taskComplete = true;
            }
            if (currentStage == 6) {   //pick up inventory item
                titleText.text = "";
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
            currentStage++;
        }
    }
}
