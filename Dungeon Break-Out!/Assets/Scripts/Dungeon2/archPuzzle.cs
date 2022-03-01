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
    public GameObject logPuzzle;
    public bool IsSolved { get { return puzzleState == 5; } }

    private void Start()
    {
        archTrackers = archTrackers.OrderBy(x => x.order).ToList();
    }

    // Update is called once per frame
    void Update()
    {
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
                    archTrackers.ForEach(x => x.isComplete = false);
                    puzzleState = 0;
                }
            }

            // still inside of the current doorframe
        }

        if (this.IsSolved && logPuzzle.GetComponent<MovePost1>().IsSolved)
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
