using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPuzzle2 : MonoBehaviour
{
    public InteractableItem Door;
    public Animator openDoor;
    public AudioSource doorCreak;
    bool puzzleComplete;

    private void Update()
    {
        if(Door.successfulInteraction)
        {
            openDoor.SetTrigger("unlockdoor");
            if (!puzzleComplete)
            {
                PlayDoorCreak();
            }
            TutorialManager.instance.tutorialPuzzle2Complete = true;
        }
    }

    private void PlayDoorCreak() {
        puzzleComplete = true;
        doorCreak.Play();
    }
}