using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLoad : MonoBehaviour
{
    public string containedScene;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentScene != containedScene) {
            Destroy(gameObject);
        }
    }
}
