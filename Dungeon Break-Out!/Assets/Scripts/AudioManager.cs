using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip[] backgroundMusic;
    public AudioClip currentBackgroundMusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else { if (instance != this) Debug.Log("Multiple AudioManager Instances."); }
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeBackgroundMusic(int song)
    {
        audioSource.Stop();
        audioSource.clip = backgroundMusic[song];
        audioSource.Play();
    }
}
