using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public static Hint instance;
    //private GameObject glowHint;
    private SkinnedMeshRenderer visibility;
    public Inventory playerInventory;
    public List<string> playerItemsName;
    public bool hasGem;
    public bool matchesUsed;
    public bool keyUsed;
    public List<GameObject> hintList = new List<GameObject>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }

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

            // show puzzle 1 hints
            if (!playerItemsName.Contains("Gem") && !EnableLasers.instance.usedGem)
            {
                Puzzle1Hints();
            }
            // show puzzle 2 hint
            else if (!RunePuzzle.instance.puzzleComplete)
            {
                ShowHint("Rune_Hint_LightRay_Cube");
                ShowHint("Portal_Hint_LightRay_Cube");
            }
            // show start of puzzle 3 (light pole)
            else if (!EnableLasers.instance.usedGem && RunePuzzle.instance.puzzleComplete)
            {
                ShowHint("Pole_Hint_LightRay_Cube");
            }
            // show mirror hints (puzzle 3)
            else if (!EnableLasers.instance.puzzleComplete)
            {
                ShowHint("Mirror1_Hint_LightRay_Cube");
                ShowHint("Mirror2_Hint_LightRay_Cube");
                ShowHint("Mirror3_Hint_LightRay_Cube");
            }
            // puzzles complete
            else
            {
                UIController.instance.ActivateDialog("Sorry, no more hints to give");
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
        if (unlockBox.instance.boxOpened == false)
        {
            ShowHint("Box_Hint_LightRay_Cube");
        }
        else if (playerItemsName.Contains("Matches") == false && matchesUsed == false)
        {
            ShowHint("Box_Hint_LightRay_Cube");
        }
        else if (!LightCandle.instance.candleLit)
        {
            ShowHint("Candle_Hint_LightRay_Cube");
        }
        else if (playerItemsName.Contains("Iron Key") == false && keyUsed == false)
        {
            ShowHint("Key_Hint_LightRay_Cube");
        }
        else if (unlockdoor.instance.jail_opened == false)
        {
            ShowHint("Jail_Hint_LightRay_Cube");
        }
        else if (unlockdoor.instance.jail_opened == true && playerItemsName.Contains("Gem") == false)
        {
            ShowHint("Gem_Hint_LightRay_Cube");
        }
    }

    void ShowHint(string hintObjectString)
    {
        var glowHint = new GameObject();
        glowHint = GameObject.Find(hintObjectString);
        if (glowHint)
        {
            visibility = glowHint.GetComponent<SkinnedMeshRenderer>();
            this.GetComponent<AudioSource>().Play();
            visibility.enabled = true;
            Debug.Log("Showing hint");
            hintList.Add(glowHint)  ;
        }
        else
        {
            Debug.Log("No game object named " + hintObjectString);
        }

    }

    IEnumerator DelayCode()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject hint in hintList)
        {
            var visibility = hint.GetComponent<SkinnedMeshRenderer>();
            visibility.enabled = false;
            Debug.Log("hint hidden");
        }
        hintList.Clear();
    }
}
