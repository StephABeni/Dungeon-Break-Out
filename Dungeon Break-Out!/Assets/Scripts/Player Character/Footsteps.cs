using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] walkClips;
    public AudioClip[] runClips;
    AudioSource audioSource;
    public GameObject rightDust;
    public GameObject leftDust;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void StepLeft(float stepSpeed)
    {
        float actualSpeed = CharacterAnimator.instance.snappedAnimation;

        if (stepSpeed == actualSpeed)
        {
            AudioClip clip = GetRandomClip(actualSpeed);
            audioSource.PlayOneShot(clip);
            leftDust.SetActive(true);
            StartCoroutine(DelayObjectDeactivation(leftDust));
        }

    }

    private void StepRight(float stepSpeed) {
        float actualSpeed = CharacterAnimator.instance.snappedAnimation;

        if (stepSpeed == actualSpeed) {
            AudioClip clip = GetRandomClip(actualSpeed);
            audioSource.PlayOneShot(clip);
            rightDust.SetActive(true);
            StartCoroutine(DelayObjectDeactivation(rightDust));
        }

    }

    private AudioClip GetRandomClip(float actualSpeed)
    {
        return (actualSpeed == 2f ? runClips[Random.Range(0, runClips.Length)] : walkClips[Random.Range(0, walkClips.Length)]);
    }

    IEnumerator DelayObjectDeactivation(GameObject obj) {
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
    }
}
