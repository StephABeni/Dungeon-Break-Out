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
            for (int i = 0; i < Inventory.instance.allInventorySlotInfo.Count; i++)
            {
                if (Inventory.instance.allInventorySlotInfo[i] != null
                    && Inventory.instance.allInventorySlotInfo[i].Name == "hammer")
                {
                    Debug.Log("hammer found!");
                    broken = true;
                    UIController.instance.DeactivateDialog();
                    break;
                }
            }
        }
     }
}
