using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune_Chest : MonoBehaviour
{
    public static Rune_Chest instance;
    public bool boxOpened = false;
    public Animator animator;
    public GameObject matches;
    private int nums;
    private bool got_rune1 = false;
    private bool got_rune2 = false;
    private bool got_rune3 = false;
    private bool got_rune4 = false;

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
            nums = Inventory.instance.allInventorySlotInfo.Count;
            if (!boxOpened)
            {
                Debug.Log(nums);
                Debug.Log(got_rune1);
                Debug.Log(got_rune2);
                Debug.Log(got_rune3);
                Debug.Log(got_rune4);
                for (int i = 0; i < nums; i++)
                {

                    if (Inventory.instance.allInventorySlotInfo[i] is null) {
                        break;
                    }
                    if (Inventory.instance.allInventorySlotInfo[i].Name == "rune1")
                    {
                        got_rune1 = true;
                    }
                    if (Inventory.instance.allInventorySlotInfo[i].Name == "rune2")
                    {
                        got_rune2 = true;
                    }
                    if (Inventory.instance.allInventorySlotInfo[i].Name == "rune3")
                    {
                        got_rune3 = true;
                    }
                    if (Inventory.instance.allInventorySlotInfo[i].Name == "rune4")
                    {
                        got_rune4 = true;
                    }
                }
                if (got_rune1 && got_rune2 && got_rune3 && got_rune4)
                {
                    animator.SetTrigger("unlockBox");
                    boxOpened = true;
                    matches.SetActive(true);
                }
            }
        }
    }
}
