using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] walkClips;
    public AudioClip[] runClips;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step(float stepSpeed)
    {
        float actualSpeed = CharacterAnimator.instance.snappedAnimation;

        if (stepSpeed == actualSpeed)
        {
            AudioClip clip = GetRandomClip(actualSpeed);
            audioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetRandomClip(float actualSpeed)
    {
        return (actualSpeed == 2f ? runClips[Random.Range(0, runClips.Length)] : walkClips[Random.Range(0, walkClips.Length)]);
    }
}
