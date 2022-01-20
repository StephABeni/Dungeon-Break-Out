using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    private Slider slider;

    public float FillSpeed = 0.01f;
    private float targetProgress = 1.0f;
    public GameObject timesUpText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple ProgressBar Instances.");
                Destroy(this);
            }
        }

        slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timesUpText.SetActive(false);

        targetProgress = slider.value - 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > targetProgress)
        {
            slider.value -= FillSpeed * Time.deltaTime;
        }
        else
        {
            timesUpText.SetActive(true);

        }


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
