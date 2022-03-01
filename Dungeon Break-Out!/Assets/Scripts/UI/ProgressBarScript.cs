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
}