using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour
{
    public static LightCandle instance;
    public bool CandleLit = false;
    public Inventory playerInventory;
    public List<string> playerInventoryItems;

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
            //playerInventoryItems = ScavengerHunt.instance.GetCurrentItems();
            playerInventory = Inventory.instance;
            for (int i = 0; i < 20; i++) {
                if (playerInventory.allInventorySlotInfo[i].Name != "")
                {
                    playerInventoryItems.Add(playerInventory.allInventorySlotInfo[i].Name);
                }
            }

            Debug.Log("Trying to light candles");
            Debug.Log(playerInventoryItems.Contains("Matches"));
                                        
            if (playerInventoryItems.Contains("Matches"))
            {
                Debug.Log("Trying to light candle");
                GameObject candle = GameObject.Find("Puzzle 1 Candle");
                ParticleSystem candleflames = GameObject.Find("SM_Prop_Candles_01_Preset").GetComponent<ParticleSystem>();

                candle.GetComponent<Light>().range = 5.0f;
                candle.GetComponent<Light>().intensity = 3.0f;
                candleflames.Play(true);
                CandleLit = true;
                Debug.Log("Candle lit. Remove matches from player inventory.");
            }
            
        }
    }
}
