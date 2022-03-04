using DuloGames.UI;
using System.Collections;
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
    private bool inProgress;
    public GameObject gem;

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
        if (canInteract && InputManager.instance.ePressed && !inProgress)
        {
            inProgress = true;
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

            inProgress = false;
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
        if (gameObject.name == "SM_Prop_Vase_02")
        {
            //canInteract = false;

            GameManager.instance.EnableMovement(false);
            CharacterAnimator.instance.animator.SetTrigger("pickup");
            StartCoroutine(DelayPositionChange());
        }

        replacingObject.SetActive(true);
        gameObject.SetActive(false);
        canInteract = false;

        UIController.instance.DeactivateDialog();
    }

    IEnumerator DelayPositionChange()
    {
        yield return new WaitForSeconds(5.0f);
        GameManager.instance.EnableMovement(true);
    }

    public void Bone()
    {
        if (Inventory.instance.HasItem("hammer")) {
            Break();
        } else {
            UIController.instance.ActivateDialog("I'll need something like a hammer to break this...");
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
        successfulInteraction = Inventory.instance.HasItem(keyName);

        if (successfulInteraction)
            UIController.instance.DeactivateDialog();
        else  
            UIController.instance.ActivateDialog(itemInfo.Name + " won't open... ");
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
