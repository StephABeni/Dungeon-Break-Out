using DuloGames.UI;
using DuloGames.UI.Tweens;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int maxTime;
    public float currentTime;

    private Image image;
    private Text text;

    private LevelLoader levelLoader;
    public bool showGameOverScene;
    public string sceneName;
    public int newSong;

    private void Awake()
    {
        
        currentTime = maxTime;
        text = gameObject.transform.GetComponentInChildren<Text>();
        image = gameObject.transform.GetComponentInChildren<Image>();
        image.fillAmount = 1f;
    }

    //Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentScene == "Tutorial") {
            text.text = "";
            return;
        }

        if (currentTime > 0){
            currentTime -= Time.deltaTime;
            image.fillAmount = currentTime/maxTime;
            text.text = Math.Round(currentTime).ToString() + " second(s) remaining";
        }
        else if (currentTime < 0 && !showGameOverScene)
        {
            levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
            showGameOverScene = true;
            levelLoader.LoadLevel("GameOverPage");
            levelLoader.ChangeMusic(0);
            
        }
    }
}
