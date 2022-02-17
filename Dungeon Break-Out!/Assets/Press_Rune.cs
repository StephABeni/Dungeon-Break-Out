using System.Collections;
using System.Collections.Generic;
using DuloGames.UI;
using UnityEngine;
using UnityEngine.UI;

public class Press_Rune : MonoBehaviour
{
    // Start is called before the first frame update
    UIItemInfo itemInfo;
    GameObject rune;
    private int nums;
    private bool pressed = false;
    void Awake()
    {
        itemInfo = gameObject.GetComponent<InteractableItem>().itemInfo;
        rune = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        

            nums = Inventory.instance.allInventorySlotInfo.Count;
            if ((itemInfo.Pushed && !rune.activeInHierarchy) ||
                (!itemInfo.Pushed && rune.activeInHierarchy))
            {

                for (int i = 0; i < nums; i++)
                {
                    if (Inventory.instance.allInventorySlotInfo[i].Name == gameObject.name)
                    {
                        rune.SetActive(gameObject.GetComponent<InteractableItem>().itemInfo.Pushed);
                    }
                    
                }

            }
        
        
    }
}
