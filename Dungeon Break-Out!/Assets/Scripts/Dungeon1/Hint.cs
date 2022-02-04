using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    private GameObject glowHint;
    private SkinnedMeshRenderer visibility;
    private int num_items;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            num_items = Inventory.instance.allInventorySlotInfo.Count;
            if (num_items == 0)
            {
                ShowHint("Key_Hint_LightRay_Cube");
            }
            for (int i = 0; i < num_items; i++)
            {
                if (Inventory.instance.allInventorySlotInfo[i].Name == "Iron Key")
                {
                    if (unlockBox.instance.boxOpened == false)
                    {
                        ShowHint("Box_Hint_LightRay_Cube");
                        break;
                    }
                    else if (unlockdoor.instance.jail_opened == false)
                    {
                        ShowHint("Jail_Hint_LightRay_Cube");
                        break;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hiding hint in 5 seconds");
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
        yield return new WaitForSeconds(2f);
        visibility.enabled = false;
        Debug.Log("hint hidden");
    }
}
