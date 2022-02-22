using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour
{
    public static LightCandle instance;
    public bool candleLit;
    public bool canInteract;
    public bool hasMatches;
    public string itemName;
    public GameObject candle;
    public GameObject key;
    public ParticleSystem candleflames;
    public Collider triggerCollider;

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

    private void Start()
    {
        key.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (ItemSlotNumber(itemName) >= 0)
            {
                hasMatches = true;
                UIController.instance.ActivateDialog("[Press 'E'] to light candles");
            }
            else
            {
                UIController.instance.ActivateDialog("I need to find matches to light the candles");
            }
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = false;
            UIController.instance.DeactivateDialog();

            if (candleLit)
            {
                int num = ItemSlotNumber(itemName);
                Inventory.instance.allInventorySlotInfo[num].Name = null;
                Inventory.instance.allInventorySlotInfo[num].Icon = null;
                Inventory.instance.allInventorySlotInfo[num].Description = null;
                Destroy(triggerCollider);
                key.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (canInteract && InputManager.instance.ePressed && hasMatches)
        {
            UIController.instance.DeactivateDialog();
            candleflames.GetComponent<ParticleSystem>();
            candle.GetComponent<Light>().range = 5.0f;
            candle.GetComponent<Light>().intensity = 3.0f;
            candleflames.Play(true);
            Inventory.instance.RemoveItem(itemName);
            candleLit = true;
            canInteract = false;
            hasMatches = false;
            Hint.instance.matchesUsed = true;
        }
    }

    int ItemSlotNumber(string item)
    {
        for (int i = 0; i < Inventory.instance.allInventorySlotInfo.Count; i++)
        {
            if (Inventory.instance.allInventorySlotInfo[i].Name == item)
            {
                return i;
            }
        }
        return -1;
    }
}
