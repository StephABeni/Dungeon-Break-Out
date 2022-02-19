using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockBox : MonoBehaviour
{
    public static unlockBox instance;
    public bool boxOpened = false;
    public bool canInteract;
    public Animator animator;
    public GameObject matches;
    public Collider triggerCollider;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }

    private void Start()
    {
        matches.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIController.instance.ActivateDialog("[Press 'E'] to open box");
            canInteract = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = false;
        }
    }

    void Update()
    {
        if (canInteract && InputManager.instance.ePressed)
        {
            UIController.instance.DeactivateDialog();
            StartCoroutine(DelayCode());
            animator.SetTrigger("unlockBox");
            boxOpened = true;
            Destroy(triggerCollider);
            canInteract = false;
        }
    }

    IEnumerator DelayCode()
    {
        yield return new WaitForSeconds(1.5f);
        matches.SetActive(true);
    }
}
