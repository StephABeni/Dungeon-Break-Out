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
        if (image.fillAmount > 0)
        {
            currentTime -= Time.deltaTime;
            image.fillAmount = currentTime/maxTime;
            text.text = Math.Round(currentTime).ToString() + " seconds.";
        }
        else
        {
            UIController.instance.GameOver.SetActive(true);
        }
    }
}
