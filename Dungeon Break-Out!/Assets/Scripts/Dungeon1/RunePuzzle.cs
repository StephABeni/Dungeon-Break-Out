using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePuzzle : MonoBehaviour
{
    public static RunePuzzle instance;
    public List<RuneShelf> runeData = new List<RuneShelf> ( new RuneShelf[8]);
    private int count;
    public bool puzzleComplete = false;
    public GameObject target;

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

    // Start is called before the first frame update
    void Start()
    {
        target.GetComponent<MeshRenderer>().enabled = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;
        for (int i = 0; i < 8; i++)
        {
            if (runeData[i].correct)
            {
                count++;
            }
        }
        if (count == 8)
        {
            Debug.Log("Winner Winner Chicken Dinner!");
            target.GetComponent<MeshRenderer>().enabled = true;
            puzzleComplete = true;
        }
    }
}
