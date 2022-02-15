using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    public GameObject tutorialPopUp;
    public GameObject enterToContinue;
    public Text titleText;
    public Text descriptionText;
    public int currentStage = 0;
    public bool taskComplete = false;

    public bool tutorialPuzzle1Complete;
    public bool tutorialPuzzle2Complete;
    public bool tutorialGemPlaced;
    public bool bridgeRaised;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple TutorialManager Instances.");
                Destroy(this);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TutorialStage1();
        TutorialStage2();
    }

    private void TutorialStage1()
    {
        if (currentStage < 6)
        {
            tutorialPopUp.SetActive(true);

            if (currentStage == 0)
            { //walk
                titleText.text = "How To: Walk";
                descriptionText.text = "You've found yourself in a strange dungeon! How you got here is anyone's guess..." +
                    "\n\nUse the WASD keys to walk around and try and find a way out.";
                if (InputManager.instance.movementInput != Vector2.zero)
                    taskComplete = true;
            }
            if (currentStage == 1)
            { // run
                titleText.text = "How To: Run";
                descriptionText.text = "Perhaps you should move with a bit more urgency?" +
                    "\n\nPress 'Shift' while walking to run";
                if (CharacterAnimator.instance.snappedAnimation == 2f)
                    taskComplete = true;
            }
            if (currentStage == 2)
            { // mouselook
                titleText.text = "How To: Look Around";
                descriptionText.text = "It's important to take in your surroundings when trying to find a way out." +
                    "\n\n Move the mouse to look in different directions. " +
                    "\nIf you move the mouse while walking, you will move relative to the direction you're looking.";
                if (InputManager.instance.lookInput != Vector2.zero)
                    taskComplete = true;
            }
            if (currentStage == 3)
            { //telekinesis mode
                titleText.text = "How To: Move Objects (1/3)";
                descriptionText.text = "Sometimes to progress, you will need to move an object somewhere else (Note: Not all objects are movable). You can either push an object by " +
                    "walking into it, or you can move it with your mind!" +
                    "\n\nClick the right mouse button to concentrate! ";
                if (InputManager.instance.rightMousePressed == true)
                    taskComplete = true;
            }
            if (currentStage == 4)
            { //pick up object in tk
                titleText.text = "How To: Move Objects (2/3)";
                descriptionText.text = "While concentrating, look at a nearby object (for example, the golden cube on the ground)." +
                    "\n\nIf it sparkles, you can press 'E' to lift it up! If it doesn't sparkle at first, try walking closer to it.";
                if (GameObject.Find("Player").GetComponent<Telekinesis>().currentlyHeldObject != null)
                    taskComplete = true;
            }
            if (currentStage == 5)
            { //drop object in tk
                titleText.text = "How To: Move Objects (3/3)";
                descriptionText.text = "You can move while holding this object, but you probably don't want to hang onto it forever, right?" +
                    "\n\nPress 'E' again to drop the item, or break your concentration by clicking the right mouse button again.";
                if (GameObject.Find("Player").GetComponent<Telekinesis>().currentlyHeldObject == null)
                    taskComplete = true;
            } 
            EnterToContinue();
        }
        else
        {
            tutorialPopUp.SetActive(false);
        }
    }

    private void TutorialStage2()
    {
        if (currentStage < 13)
        {
            tutorialPopUp.SetActive(true);
            if (currentStage == 6) { 
                titleText.text = "Exit the Room";
                descriptionText.text = "Figure out how to open the door to get out.";
                if (tutorialPuzzle1Complete)
                    taskComplete = true;
            }
            if (currentStage == 7)
            {   //pick up inventory item
                titleText.text = "How To: Pick Up Objects(1/3)";
                descriptionText.text = "You won't always be able to progress just by moving some objects around. Sometimes you need to have a " +
                    "special item in your inventory!\n\n Look around the next room for something to help you cross to the other side of the trapped chasm.";
                if (UIController.instance.dialogText.text == "[Press 'E'] Pick Up Shining Gem" ||
                    Inventory.instance.allInventorySlotInfo[0].Name != "")
                    taskComplete = true;
            }
            if (currentStage == 8)
            {
                titleText.text = "How To: Pick Up Objects(2/3)";
                descriptionText.text = "You found it! Go ahead and pick it up.";
                if (Inventory.instance.allInventorySlotInfo[0].Name != "")
                    taskComplete = true;

            }
            if (currentStage == 9) {
                titleText.text = "How To: Pick Up Objects(3/3)";
                descriptionText.text = "You can Open/Close your inventory to see what items you have by pressing 'Tab'." +
                    "\n\nYou can move your items by clicking and dragging them. You can also read their descriptions " +
                    "by hovering over the icons.";
                if (InputManager.instance.tabPressed)
                    taskComplete = true;
            }
            if (currentStage == 10) {
                titleText.text = "Interacting With The World";
                descriptionText.text = "Now that you have an item in your inventory, you will be able to interact with something you weren't able to before." +
                    "Figure out where the crystal goes and place it.";
                if (tutorialGemPlaced) {
                    currentStage++;
                }
            }
            if (currentStage == 11) {
                titleText.text = "Lift the Bridge";
                descriptionText.text = "Great work! Now, see if you can get that bridge to raise up so you can cross.";
                if (bridgeRaised) {
                    currentStage++;
                }
            }
            if (currentStage == 12) {
                titleText.text = "Get out of here!";
                descriptionText.text = "The way across has opened up! Only a measly door stands in your way now. You already know everything you need to move forward from here.";
                if (GameManager.instance.currentScene != "Tutorial") {
                    currentStage++;
                }
            }
            EnterToContinue();
        }
        else
        {
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
