using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour
{
    private LevelLoader levelLoader;
    public string sceneName;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
            levelLoader.LoadLevel(sceneName); 
            GameManager.instance.player.SetActive(false);
        }
    }
}
