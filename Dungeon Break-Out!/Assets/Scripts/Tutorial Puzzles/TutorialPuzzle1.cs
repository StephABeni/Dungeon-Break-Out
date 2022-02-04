using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPuzzle1 : MonoBehaviour
{
    public GameObject Ring1;
    public GameObject Ring2;
    public Animator openDoor;
    public AudioSource doorCreak;
    public bool puzzleComplete = false;

    private void Update()
    {
        if(Ring1.activeInHierarchy && Ring2.activeInHierarchy)
        {
            openDoor.SetTrigger("unlockdoor");
            if (!puzzleComplete)
            {
                PlayDoorCreak();
            }
            TutorialManager.instance.tutorialPuzzle1Complete = true;
        }
    }

    private void PlayDoorCreak() {
        puzzleComplete = true;
        doorCreak.Play();
    }
}