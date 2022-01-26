using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    InputManager inputManager;
    public GameObject reticle;
    public GameObject dialog;
    public Text dialogText;
    public GameObject InventoryIcon;
    public GameObject InventoryWindow;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple UIController Instances.");
                Destroy(this);
            }
        }
    }

    private void Start()
    {
        inputManager = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        reticle.SetActive(inputManager.rightMousePressed);
        InventoryWindow.SetActive(inputManager.tabPressed);
        Time.timeScale = inputManager.tabPressed ? 0 : 1;
    }

    public void ActivateDialog(string text)
    {
        dialog.SetActive(true);
        dialogText.text = text;
    }

    public void DeactivateDialog()
    {
        dialog.SetActive(false);
    }

    public void ShowInventoryIcon()
    {
        StartCoroutine(DelayIcon());
    }

    public void HideInventoryWindow()
    {
        inputManager.tabPressed = false;
    }

    IEnumerator DelayIcon()
    {
        yield return new WaitForSeconds(1f);
        InventoryIcon.SetActive(!InventoryIcon.activeInHierarchy);
    }
}