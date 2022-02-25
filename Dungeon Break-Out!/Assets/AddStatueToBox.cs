using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStatueToBox : MonoBehaviour
{
    public GameObject gemLight;
    public GameObject statue;
    public bool isComplete;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == statue && !isComplete)
        //if (other.tag == "statue")
        {
            gemLight.SetActive(true);
            isComplete = true;
            //if (itemInfo.ItemType == 5) return;
            //UIController.instance.ActivateDialog("[Press 'E'] Move Post");
            //canInteract = true;
        }
    }

}
