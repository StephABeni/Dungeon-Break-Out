using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFinale : MonoBehaviour
{
    public AudioSource cheerAudio;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            AudioManager.instance.ChangeBackgroundMusic(4);
            cheerAudio.Play();
        }
    }
}
