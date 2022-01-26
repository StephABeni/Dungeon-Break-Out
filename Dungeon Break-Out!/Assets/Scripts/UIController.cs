using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    InputManager inputManager;
    public GameObject reticle;

    private void Start()
    {
        inputManager = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        reticle.SetActive(inputManager.rightMousePressed);
    }
}
