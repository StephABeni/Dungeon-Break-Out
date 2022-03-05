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
    public GameObject toolTipPopup2;
    public Text toolTipTitle2;
    public Text toolTipDescription2;

    private void Start()
    {
        TooltipLayer = LayerMask.NameToLayer("Tooltip");
    }

    private void Update()
    {
        if (!IsPointerOverUIElement(GetEventSystemRaycastResults()))
        {
            HideToolTip();
        }
    }

    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == TooltipLayer)
            {
                UIItemInfo slotInfo = curRaysastResult.gameObject.GetComponentInParent<UIItemSlot>().GetItemInfo();
                if (slotInfo != null)
                {
                    if (slotInfo.Description.StartsWith("Incribed"))
                    {
                        ShowToolTip2(slotInfo);
                    }
                    else
                    {
                        ShowToolTip(slotInfo);
                    }
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

    private void ShowToolTip2(UIItemInfo tooltipInfo)
    {
        toolTipTitle2.text = tooltipInfo.Name;
        toolTipDescription2.text = tooltipInfo.Description;
        toolTipPopup2.SetActive(true);
    }

    private void HideToolTip()
    {
        toolTipPopup.SetActive(false);
        toolTipPopup2.SetActive(false);
    }


}
