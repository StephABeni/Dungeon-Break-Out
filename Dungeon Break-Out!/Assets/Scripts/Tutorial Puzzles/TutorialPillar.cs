using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPillar : MonoBehaviour
{
    GameObject ringFX;

    private void Awake()
    {
        ringFX = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TutorialPuzzle1")
        {
            ringFX.SetActive(true);
                
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TutorialPuzzle1")
        {
            ringFX.SetActive(false);

        }
    }
}
