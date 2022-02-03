using DuloGames.UI;
using DuloGames.UI.Tweens;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //public static Timer instance;
    public enum TextVariant
    {
        Percent,
        Value,
        ValueMax
    }

    public UIProgressBar bar;
    public float Duration = 50f;
    public TweenEasing Easing = TweenEasing.Linear;
    public Text m_Text;
    public TextVariant m_TextVariant = TextVariant.Percent;
    public int m_TextValue = 0;
    public string m_TextValueFormat = "0";

    protected Timer()
    {
        if (this.m_FloatTweenRunner == null)
            this.m_FloatTweenRunner = new TweenRunner<FloatTween>();

        this.m_FloatTweenRunner.Init(this);
    }

    // Tween controls
    [NonSerialized] private readonly TweenRunner<FloatTween> m_FloatTweenRunner;

    public float FillSpeed = 0.01f;
    //public GameObject timesUpText;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);

    //    //if (instance == null) instance = this;
    //    //else
    //    //{
    //    //    if (instance != this)
    //    //    {
    //    //        Debug.Log("Multiple Timer Bar Instances.");
    //    //        Destroy(this);
    //    //    }
    //    //}

    //    slider = gameObject.GetComponent<Slider>();
    //}

    // Start is called before the first frame update
    //void Start()
    //{
    //    SetupTimer();
    //}

    protected void OnEnable()
    {
        if (this.bar == null)
            return;

        this.StartTween(0f, (this.bar.fillAmount * this.Duration));
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (slider.value > 0)
    //    {
    //        slider.value -= FillSpeed * Time.deltaTime;
    //    }
    //    else
    //    {
    //        timesUpText.SetActive(true);
    //    }
    //}


    protected void SetFillAmount(float amount)
    {
        if (this.bar == null)
            return;

        this.bar.fillAmount = amount;

        if (this.m_Text != null)
        {
            if (this.m_TextVariant == TextVariant.Percent)
            {
                this.m_Text.text = Mathf.RoundToInt(amount * 100f).ToString() + "%";
            }
            else if (this.m_TextVariant == TextVariant.Value)
            {
                this.m_Text.text = ((float)this.m_TextValue * amount).ToString(this.m_TextValueFormat);
            }
            else if (this.m_TextVariant == TextVariant.ValueMax)
            {
                this.m_Text.text = ((float)this.m_TextValue * amount).ToString(this.m_TextValueFormat) + "/" + this.m_TextValue;
            }
        }
    }


    protected void OnTweenFinished()
    {
        if (this.bar == null)
            return;

        //timesUpText.SetActive(true);
    }


    protected void StartTween(float targetFloat, float duration)
    {
        if (this.bar == null)
            return;

        var floatTween = new FloatTween { duration = duration, startFloat = this.bar.fillAmount, targetFloat = targetFloat };
        floatTween.AddOnChangedCallback(SetFillAmount);
        floatTween.AddOnFinishCallback(OnTweenFinished);
        floatTween.ignoreTimeScale = true;
        floatTween.easing = this.Easing;
        this.m_FloatTweenRunner.StartTween(floatTween);
    }
}



//using UnityEngine.UI;
//using UnityEngine;

//public class Timer : MonoBehaviour
//{
//    Image timerBar;
//    public float maxTime = 1800f;
//    float timeLeft;
//    public GameObject timesUpText;

//    // Start is called before the first frame update
//    void Start()
//    {
//        timesUpText.SetActive(false);
//        timerBar = GetComponent<Image>();
//        timeLeft = maxTime;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(timeLeft > 0)
//        {
//            timeLeft -= Time.deltaTime;
//            timerBar.fillAmount = timeLeft / maxTime;
//        }
//        else
//        {
//            timesUpText.SetActive(true);
//            Time.timeScale = 0;
//        }
//    }
//}
