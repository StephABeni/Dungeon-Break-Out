using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public string sceneName;
    public int newSong;
    public Vector3 spawnLocation;
    private LevelLoader levelLoader;

    private void Awake()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CharacterMovement.instance.SetCurrentPosition(spawnLocation, true);
            levelLoader.LoadLevel(sceneName);
            if(newSong > 0) {
                levelLoader.ChangeMusic(newSong);
            }
        }
    }
}
