using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint : MonoBehaviour
{
    //private Renderer visible;
    //private Renderer visible2;
    //private Renderer visible3;
    //private GameObject hints;
    //private GameObject hints2;
    //private GameObject hints3;
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
            //hints2 = GameObject.Find("FX_Spiral 2");
            //hints3 = GameObject.Find("FX_Spiral");
            //visible = hints.GetComponent<Renderer>();
            //visible2 = hints2.GetComponent<Renderer>();
            //visible3 = hints3.GetComponent<Renderer>();
            //visible.enabled = true;
            //visible2.enabled = true;
            //visible3.enabled = true;
            Debug.Log("Showing hint");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //hints = GameObject.Find("FX_Spiral 1");
            //hints2 = GameObject.Find("FX_Spiral 2");
            //hints3 = GameObject.Find("FX_Spiral");
            //visible = hints.GetComponent<Renderer>();
            //visible2 = hints2.GetComponent<Renderer>();
            //visible3 = hints3.GetComponent<Renderer>();
            //visible.enabled = false;
            //visible2.enabled = false;
            //visible3.enabled = false;
            //glowHint = GameObject.FindWithTag("Hint");
            //visibility = glowHint.GetComponent<SkinnedMeshRenderer>();
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
