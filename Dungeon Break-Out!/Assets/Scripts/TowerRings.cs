using DuloGames.UI;
using UnityEngine;
using UnityEngine.UI;

public class TowerRings : MonoBehaviour
{
    UIItemInfo itemInfo;
    GameObject ring;

    private void Awake()
    {
        itemInfo = gameObject.GetComponent<InteractableItem>().itemInfo;
        ring = gameObject.transform.GetChild(0).gameObject;
    }

    public void Update()
    {
        if ((itemInfo.Pushed && !ring.activeInHierarchy) ||
            (!itemInfo.Pushed && ring.activeInHierarchy))
        {
            ring.SetActive(gameObject.GetComponent<InteractableItem>().itemInfo.Pushed);
        }
    }
}

