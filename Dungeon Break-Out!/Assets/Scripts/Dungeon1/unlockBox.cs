using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockBox : MonoBehaviour
{
    public static unlockBox instance;
    private int numItems;
    public bool boxOpened = false;
    public Animator animator;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple Inventory Instances.");
                Destroy(this);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            numItems = Inventory.instance.allInventorySlotInfo.Count;
            Debug.Log(numItems);
            if (boxOpened == false)
            {
                for (int i = 0; i < numItems; i++)
                {
                    if (Inventory.instance.allInventorySlotInfo[i].Name == "Iron Key")
                    {
                        animator.SetTrigger("unlockBox");
                        boxOpened = true;
                        Debug.Log("Box opened. Add matches to player inventory.");
                    }
                }
            }
        }
    }
}
