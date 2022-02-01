using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{
    public static ProgressBarScript instance;

    private Slider slider;

    public float FillSpeed = 0.1f;
    private float targetProgress = 0;

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
        targetProgress = slider.value + 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }


    }
}