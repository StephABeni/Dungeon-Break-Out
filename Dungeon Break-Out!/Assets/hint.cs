using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    //private Renderer visible;
    //private GameObject hints;
    private GameObject glowHint;
    private SkinnedMeshRenderer visibility;
    private int num_items;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            num_items = Inventory.instance.allInventorySlots.Count;
            {
                for (int i = 0; i < num_items; i++)
                {
                    if (Inventory.instance.allInventorySlotInfo[i].Name == "Iron Key")
                    {
                        if (unlockBox.instance.boxOpened == false)
                        {
                            glowHint = GameObject.Find("Box_Hint_LightRay_Cube");
                            visibility = glowHint.GetComponent<SkinnedMeshRenderer>();
                            visibility.enabled = true;
                            Debug.Log("Showing hint");
                        }
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //hints = GameObject.Find("FX_Spiral 1");
            //visible = hints.GetComponent<Renderer>();
            //visible.enabled = false;
            Debug.Log("hiding hint in 5 seconds");
            StartCoroutine(DelayCode());
            Debug.Log("hint hidden");
        }
    }

    IEnumerator DelayCode()
    {
        yield return new WaitForSeconds(5f); //amount of time
                                             //do the code you want delayed here
        glowHint = GameObject.Find("Box_Hint_LightRay_Cube");
        visibility = glowHint.GetComponent<SkinnedMeshRenderer>();
        visibility.enabled = false;
    }
}
