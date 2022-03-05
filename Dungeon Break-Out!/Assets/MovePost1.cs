using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePost1 : MonoBehaviour
{
    private bool canInteract;
    private int currentSlot;
    public GameObject statuePuzzle;

    public bool IsSolved { get { return currentSlot == 2; } }
    private Vector3[] slots = { new Vector3(8.9999f, 1.2728f, -5.35f), new Vector3(8.9999f, 1.2728f, -5.85f), new Vector3(8.9999f, 1.2728f, -6.5f), new Vector3(8.9999f, 1.2728f, -7.0f) };
    private void Awake()
    {
        currentSlot = 0;
    }

    private void Update()
    {
        if (canInteract && InputManager.instance.ePressed)
        {
            if (statuePuzzle.GetComponent<AddStatueToBox>().isComplete)
            {
                Move();
            }
            else
            {
                // add something to say doesn't work
            }
        }
    }


    private void Move()
    {
        currentSlot++;
        currentSlot = currentSlot % slots.Length;
        gameObject.transform.position = slots[currentSlot];
        UIController.instance.DeactivateDialog();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //if (itemInfo.ItemType == 5) return;
            UIController.instance.ActivateDialog("[Press 'E'] Move Post");
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
