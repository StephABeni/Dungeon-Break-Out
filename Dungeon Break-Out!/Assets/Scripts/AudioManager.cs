using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audio;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else { if (instance != this) Debug.Log("Multiple AudioManager Instances."); }
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
