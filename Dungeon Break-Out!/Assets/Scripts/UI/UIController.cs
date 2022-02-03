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
    public GameObject TimerUI;
    public GameObject GameOver;
    public GameObject Tutorial;

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
        if(GameManager.instance.currentScene != "StartPage" && GameManager.instance.currentScene != "CharacterSelect")
        {
            if(GameManager.instance.currentScene != "Tutorial")
                TimerUI.SetActive(true);
            Tutorial.SetActive(true);
        } else {
            TimerUI.SetActive(false);
            Tutorial.SetActive(false);
        }
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
