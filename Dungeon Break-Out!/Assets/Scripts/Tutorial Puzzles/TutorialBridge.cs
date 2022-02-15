using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBridge : MonoBehaviour
{
    public bool canInteract;
    public GameObject gem;
    public Animator bridgeAnimator;
    public Animator leverAnimator;
    public AudioSource bridgeAudio;

    // Update is called once per frame
    void Update()
    {
        if (canInteract && InputManager.instance.ePressed) {
            Activate();
        }
    }

    public void Activate() {
        if (gem.activeInHierarchy) {
            leverAnimator.SetTrigger("raise");
            StartCoroutine(DelayBridgeAnimation());
            UIController.instance.DeactivateDialog();
        }
        else {
            UIController.instance.ActivateDialog("Nothing happens... maybe it's not properly powered?");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            UIController.instance.ActivateDialog("[Press 'E'] Move Lever");
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            canInteract = false;
            UIController.instance.DeactivateDialog();
        }
    }

    IEnumerator DelayBridgeAnimation() {
        yield return new WaitForSeconds(2f);
        bridgeAnimator.SetTrigger("raise");
        bridgeAudio.Play();
        TutorialManager.instance.bridgeRaised = true;
    }
}
