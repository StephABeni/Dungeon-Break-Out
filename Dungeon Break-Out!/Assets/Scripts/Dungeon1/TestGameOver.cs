using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameOver : MonoBehaviour
{
    public string sceneName;
    public int newSong;
    private LevelLoader levelLoader;

    private void Awake()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelLoader.LoadLevel(sceneName);
            if (newSong > 0)
            {
                levelLoader.ChangeMusic(newSong);
            }
        }
    }
}
