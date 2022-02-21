using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class archPuzzle : MonoBehaviour
{

    public int puzzleState = 0;
    public List<archTracker> archTrackers;
    public Animator openDoor;
    public AudioSource doorCreak;
    bool puzzleComplete;

    private void Start()
    {
        archTrackers = archTrackers.OrderBy(x => x.order).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < archTrackers.Count; i++)
        //{
        archTracker curTracker = archTrackers.Where(x => x.triggerEntered).FirstOrDefault();

        if (curTracker != default(archTracker))
        {
            if (!curTracker.isComplete)
            {
                if(curTracker.order == puzzleState)
                {
                    curTracker.isComplete = true;
                    puzzleState++;
                }
                else
                {
                    archTrackers.All(x => x.isComplete = false);
                    puzzleState = 0;
                }
            }

            // still inside of the current doorframe
        }


        if (puzzleState == 5)
        {
            openDoor.SetTrigger("unlockdoor");
            if (!puzzleComplete)
            {
                PlayDoorCreak();
            }
        }
    }


    private void PlayDoorCreak()
    {
        puzzleComplete = true;
        doorCreak.Play();
    }
}
