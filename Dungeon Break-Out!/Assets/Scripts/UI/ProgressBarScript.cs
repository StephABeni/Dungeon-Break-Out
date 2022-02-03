using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{
    public static ProgressBarScript instance;

    public float FillSpeed = 0.1f;
    private float targetProgress = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple ProgressBar Instances.");
                Destroy(this);
            }
        }
    }

/*    // Start is called before the first frame update
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


    }*/
}