using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockdoor : MonoBehaviour
{
    public static unlockdoor instance;
    private int num_items;
    public bool jail_opened = false;
    public Animator animator;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
            num_items = Inventory.instance.allInventorySlots.Count;
            Debug.Log(num_items);
            if (jail_opened == false)
            {
                for (int i = 0; i < num_items; i++)
                {
                    if (Inventory.instance.allInventorySlotInfo[i].Name == "Iron Key")
                    {
                        animator.SetTrigger("unlockdoor");
                        Debug.Log("Jail opened.");
                        jail_opened = true;
                    }
                }
            }

        }
    }
}
