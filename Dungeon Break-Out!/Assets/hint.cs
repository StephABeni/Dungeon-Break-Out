using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint : MonoBehaviour
{
    //private Renderer visible;
    //private GameObject hints;
    private GameObject glowHint;
    private SkinnedMeshRenderer visibility;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            glowHint = GameObject.FindWithTag("Hint");
            visibility = glowHint.GetComponent<SkinnedMeshRenderer>();
            visibility.enabled = true;
            //hints = GameObject.Find("FX_Spiral 1");
            //visible = hints.GetComponent<Renderer>();
            //visible.enabled = true;
            Debug.Log("Showing hint");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //hints = GameObject.Find("FX_Spiral 1");
            //visible = hints.GetComponent<Renderer>();
            //visible.enabled = false;
            Debug.Log("hiding hint in 5 seconds");
            StartCoroutine(DelayCode());
            Debug.Log("hint hidden");
        }
    }

    IEnumerator DelayCode()
    {
        yield return new WaitForSeconds(5f); //amount of time
                                              //do the code you want delayed here
        glowHint = GameObject.FindWithTag("Hint");
        visibility = glowHint.GetComponent<SkinnedMeshRenderer>();
        visibility.enabled = false;
    }
}
