using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    private GameObject glowHint;
    private SkinnedMeshRenderer visibility;
    private int num_items = 0;
    public List<DuloGames.UI.UIItemInfo> playerInventory;
    public List<string> playerInventoryItems;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInventory = Inventory.instance.allInventorySlotInfo;
            num_items = GetCurrentInventoryCount(playerInventory, playerInventoryItems);

            if (num_items == 0)
            {
                ShowHint("Key_Hint_LightRay_Cube");
            }

            if (playerInventoryItems.Contains("Iron Key"))
            {
                if (unlockBox.instance.boxOpened == false)
                {
                    ShowHint("Box_Hint_LightRay_Cube");
                }
                else if (unlockdoor.instance.jail_opened == false)
                {
                    ShowHint("Jail_Hint_LightRay_Cube");
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hiding hint in 1.5 seconds");
            StartCoroutine(DelayCode());
        }
    }

    void ShowHint(string hintObjectString)
    {
        glowHint = GameObject.Find(hintObjectString);
        visibility = glowHint.GetComponent<SkinnedMeshRenderer>();
        visibility.enabled = true;
        Debug.Log("Showing hint");
    }

    IEnumerator DelayCode()
    {
        yield return new WaitForSeconds(1.5f);
        visibility.enabled = false;
        Debug.Log("hint hidden");
    }

    int GetCurrentInventoryCount(List<DuloGames.UI.UIItemInfo>currentInventory, List<string>currentItems)
    {
        int count = 0;

        for (int i = 0; i < 20; i++)
        {
            if (currentInventory[i].Name != "")
            {
                currentItems.Add(currentInventory[i].Name);
                count++;
            }
        }
        return count;
    }
}
