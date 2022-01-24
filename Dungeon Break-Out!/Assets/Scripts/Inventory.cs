using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private List<Item> itemlist;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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

    // Start is called before the first frame update
    void Start()
    {
        itemlist = new List<Item>();
    }

    public void AddItem(Item item)
    {
        itemlist.Add(item);
        Debug.Log("Added " + item.itemName + " to inventory");
    }


}
