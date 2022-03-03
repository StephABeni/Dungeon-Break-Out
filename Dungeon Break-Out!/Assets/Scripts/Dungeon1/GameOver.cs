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
        clearInventory();
        GameManager.instance.player.SetActive(false);
    }

    public void Replay()
    {
        GameManager.instance.player.SetActive(true);
        CharacterMovement.instance.SetCurrentPosition(spawnLocation, true);
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        timer.currentTime = 2000;
        timer = GameObject.Find("Timer Bar").GetComponent<Timer>();
        timer.currentTime = 2000;
        timer.showGameOverScene = false;
        levelLoader.LoadLevel(sceneName);
        if (newSong > 0)
        {
            levelLoader.ChangeMusic(newSong);
        }
    }

    private void clearInventory()
    {
        for (int i = 0; i < Inventory.instance.allInventorySlotInfo.Count; i++)
        {
            if (Inventory.instance.allInventorySlotInfo[i].Name != null)
            {
                Inventory.instance.RemoveItem(Inventory.instance.allInventorySlotInfo[i].Name);
                Inventory.instance.allInventorySlotInfo[i].Name = null;
                Inventory.instance.allInventorySlotInfo[i].Icon = null;
                Inventory.instance.allInventorySlotInfo[i].Description = null;
            }
        }
    }
}
