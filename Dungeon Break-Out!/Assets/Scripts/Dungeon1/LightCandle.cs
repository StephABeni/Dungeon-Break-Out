using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour
{
    public static LightCandle instance;
    public bool CandleLit = false;
    public Inventory playerInventory;

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
            
            if (CandleLit)
            {
                return;
            }

            playerInventory = Inventory.instance;

            for (int i = 0; i < 20; i++)
            {
                if (playerInventory.allInventorySlotInfo[i].Name == "Matches")
                {
                    Debug.Log("Trying to light candle");
                    GameObject candle = GameObject.Find("Puzzle 1 Candle");
                    ParticleSystem candleflames = GameObject.Find("SM_Prop_Candles_01_Preset").GetComponent<ParticleSystem>();

                    candle.GetComponent<Light>().range = 5.0f;
                    candle.GetComponent<Light>().intensity = 3.0f;
                    candleflames.Play(true);
                    CandleLit = true;

                    //playerInventory.allInventorySlotInfo[i] = new DuloGames.UI.UIItemInfo();
                    playerInventory.allInventorySlotInfo[i].Name = null;
                    playerInventory.allInventorySlotInfo[i].Description = null;
                    playerInventory.allInventorySlotInfo[i].Icon = null;
                    playerInventory.allInventorySlotInfo[i].ItemType = 0;
                    Debug.Log("Candle lit. Removed matches from player inventory.");
                    break;
                }
            }
            if (!CandleLit)
            {
                Debug.Log("Pick up matches to light candle");
            }
        }
    }
}
