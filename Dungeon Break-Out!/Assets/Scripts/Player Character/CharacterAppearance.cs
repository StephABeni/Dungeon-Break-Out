using System.Collections.Generic;
using UnityEngine;

public class CharacterAppearance : MonoBehaviour
{
    public static CharacterAppearance instance;
    public List<GameObject> appearances;
    private int currentAppearance = 8;

    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple CharacterAppearance Instances.");
                Destroy(this);
            }
        }
    }

    void DeactivateCurrentAppearance()
    {
        appearances[currentAppearance].SetActive(false);
    }

    void ActivateAppearance(int value)
    {
        currentAppearance = value >= appearances.Count ? 0 : (value < 0 ? appearances.Count-1 : value);
        appearances[currentAppearance].SetActive(true);
    }

    public void ChangeAppearance(int direction)
    {
        DeactivateCurrentAppearance();
        ActivateAppearance(currentAppearance + direction);
    }
}
