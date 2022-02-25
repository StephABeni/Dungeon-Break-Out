using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Vector3 spawnLocation;
    private LevelLoader levelLoader;
    public string sceneName;
    public int newSong;

    private void Awake()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.ChangeBackgroundMusic(4);
        GameManager.instance.player.SetActive(false);
    }

    public void Replay()
    {
        GameManager.instance.player.SetActive(true);
        CharacterMovement.instance.SetCurrentPosition(spawnLocation, true);
        levelLoader.LoadLevel(sceneName);
        if (newSong > 0)
        {
            levelLoader.ChangeMusic(newSong);
        }
    }
}
