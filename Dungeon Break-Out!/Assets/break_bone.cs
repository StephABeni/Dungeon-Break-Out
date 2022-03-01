using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_bone : MonoBehaviour
{
    // Start is called before the first frame update
    private int total_item;
    public bool broken;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            total_item = Inventory.instance.allInventorySlotInfo.Count;
            if (broken == false) 
            {
                for (int i = 0; i < total_item; i++)
                {
                    if (Inventory.instance.allInventorySlotInfo[i].Name == "hammer")
                    {
                        broken = true;
                    }
                }
            }
        }
    }
}
