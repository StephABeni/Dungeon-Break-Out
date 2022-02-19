using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    private GameObject glowHint;
    private SkinnedMeshRenderer visibility;
    private int num_items = 0;
    public Inventory playerInventory;
    public List<string> playerItemsName;
    public bool puzzle1Complete;
    public bool puzzle2Complete;
    public bool puzzle3Complete;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInventory = Inventory.instance;

            for (int i = 0; i < 20; i++)
            {
                if (playerInventory.allInventorySlotInfo[i] != null)
                {
                    playerItemsName.Add(playerInventory.allInventorySlotInfo[i].Name);
                }
            }

            if (!puzzle1Complete)
            {
                Puzzle1Hints();
            }
            else if (!puzzle2Complete)
            {
                Puzzle2Hints();
            }
            else if (puzzle1Complete && puzzle2Complete)
            {
                // showhint of laser start thing
            }
            else if (!puzzle3Complete)
            {
                // showhint of all laser pads
            }
            else
            {
                // UI 'sorry no more hints to give'
            }


        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hiding hint in 1 second");
            playerItemsName.Clear();
            StartCoroutine(DelayCode());
        }
    }

    void Puzzle1Hints()
    {
        if ((unlockBox.instance.boxOpened == false || playerItemsName.Contains("Matches") == false))
        {
            ShowHint("Box_Hint_LightRay_Cube");
        }
        else if (!LightCandle.instance.candleLit)
        {
            ShowHint("Candle_Hint_LightRay_Cube");
        }
        else if (playerItemsName.Contains("Iron Key") == false)
        {
            ShowHint("Key_Hint_LightRay_Cube");
        }
        else if (unlockdoor.instance.jail_opened == false)
        {
            ShowHint("Jail_Hint_LightRay_Cube");
        }
        else if (unlockdoor.instance.jail_opened == true)
        {
            ShowHint("Gem_Hint_LightRay_Cube");
        }
        else if (playerItemsName.Contains("Gem") == true)
        {
            puzzle1Complete = true;
        }
    }

    void Puzzle2Hints()
    {
        // showhint of rune wall and portal
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
        yield return new WaitForSeconds(1f);
        visibility.enabled = false;
        Debug.Log("hint hidden");
    }
}
