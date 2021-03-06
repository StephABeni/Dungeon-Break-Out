using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public string currentScene;
    public bool cursorLocked;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple GameManager Instances.");
                Destroy(this);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "CharacterSelect" || currentScene == "StartPage" || currentScene == "GameOverPage") {
            cursorLocked = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            if (InputManager.instance.tabPressed) {
                UnlockCursor(false);
            }
            else {
                LockCursor(false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (currentScene != "CharacterSelect" && !InputManager.instance.tabPressed && currentScene != "GameOverPage")
        {
            CharacterMovement.instance.HandleAllMovement();
        }
    }

    public void UnlockCursor(bool delayAnimator)
    {
        cursorLocked = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (delayAnimator)
        {
            StartCoroutine(DelayedAnimator(false));
        }
        else
        {
            player.GetComponent<Animator>().SetBool("Game", false);
        }
    }

    public void LockCursor(bool delayAnimator)
    {
        cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (delayAnimator)
        {
            StartCoroutine(DelayedAnimator(true));
        }
        else
        {
            player.GetComponent<Animator>().SetBool("Game", true);
        }
    }

    IEnumerator DelayedAnimator(bool lockAnimation)
    {
        yield return new WaitForSeconds(1f);
        player.GetComponent<Animator>().SetBool("Game", lockAnimation);
    }

    public void EnableMovement(bool command)
    {
        CharacterMovement.instance.enabled = command;
    }
}
