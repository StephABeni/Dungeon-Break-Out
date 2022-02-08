using DuloGames.UI;
using DuloGames.UI.Tweens;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Range(100, 1000)]
    public int FillSpeed;

    private Image image;
    private Text text;

    private void Awake()
    {
        text = gameObject.transform.GetComponentInChildren<Text>();
        image = gameObject.transform.GetComponentInChildren<Image>();
    }

    //Update is called once per frame
    void Update()
    {
        if (image.fillAmount > 0)
        {
            image.fillAmount -= 1.0f/FillSpeed * Time.deltaTime;
            text.text = image.fillAmount.ToString("P");
        }
        else
        {
            UIController.instance.GameOver.SetActive(true);
        }
    }
}
