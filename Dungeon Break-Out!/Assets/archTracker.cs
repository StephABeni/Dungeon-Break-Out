using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archTracker : MonoBehaviour
{
    public bool isComplete;
    public GameObject archEffect;
    public int order;
    public bool triggerEntered;

    public void test()
    {
        Debug.Log("TEST");
    }

    void Update()
    {
        //if (archEffect.activeInHierarchy != isCorrect)
        //{
            archEffect.SetActive(isComplete);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rollingBall" && !triggerEntered)
        {
            triggerEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "rollingBall" && triggerEntered)
        {
            triggerEntered = false;
        }
    }
}
