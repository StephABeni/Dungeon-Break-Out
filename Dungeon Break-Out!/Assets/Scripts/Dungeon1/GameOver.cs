using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Vector3 spawnLocation;
    private LevelLoader levelLoader;
    private Timer timer;
    public string sceneName;
    public int newSong;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.ChangeBackgroundMusic(0);
        GameManager.instance.player.SetActive(false);
    }

    public void Replay()
    {
        GameManager.instance.player.SetActive(true);
        CharacterMovement.instance.SetCurrentPosition(spawnLocation, true);
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        timer.currentTime = 120;
        timer = GameObject.Find("Timer Bar").GetComponent<Timer>();
        timer.currentTime = 120;
        timer.showGameOverScene = false;
        levelLoader.LoadLevel(sceneName);
        if (newSong > 0)
        {
            levelLoader.ChangeMusic(newSong);
        }
    }
}
