using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenOnStart : MonoBehaviour
{
    public void GoFullscreen()
    {
        if(Screen.fullScreen == false)
            Screen.fullScreen = true;
    }
}
