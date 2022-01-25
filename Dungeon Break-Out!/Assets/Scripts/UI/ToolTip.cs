using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DuloGames.UI;

public class ToolTip : MonoBehaviour
{
    private int TooltipLayer;
    public GameObject toolTipPopup;
    public Text toolTipTitle;
    public Text toolTipDescription;

    private void Start()
    {
        TooltipLayer = LayerMask.NameToLayer("Tooltip");
    }

    private void Update()
    {
        if (!IsPointerOverUIElement(GetEventSystemRaycastResults())) {
            HideToolTip();
        }
    }

    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == TooltipLayer) {
                UIItemInfo slotInfo = curRaysastResult.gameObject.GetComponentInParent<UIItemSlot>().GetItemInfo();
                if (slotInfo != null) {
                    ShowToolTip(slotInfo);
                    return true;
                }
            }
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = InputManager.instance.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

    private void ShowToolTip(UIItemInfo tooltipInfo)
    {
        toolTipTitle.text = tooltipInfo.Name;
        toolTipDescription.text = tooltipInfo.Description;
        toolTipPopup.SetActive(true);
    }

    private void HideToolTip()
    {
        toolTipPopup.SetActive(false);
    }


}
