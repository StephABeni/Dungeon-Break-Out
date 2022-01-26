using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public GameObject player;
    string currentScene;
    bool cursorLocked;

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
        if (currentScene != "CharacterSelect" && !InputManager.instance.tabPressed)
        {
            if (!cursorLocked) {
                LockCursor(false);
            }
        }
        else
        {
            if (cursorLocked) {
                UnlockCursor(false);
            }
        }
    }

    private void FixedUpdate()
    {
        if(currentScene != "CharacterSelect" && !InputManager.instance.tabPressed)
        {
            CharacterMovement.instance.HandleAllMovement();
        }
    }

    public void UnlockCursor(bool delayAnimator)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (delayAnimator)
        {
            StartCoroutine(DelayedAnimator(false));
        } else
        {
            player.GetComponent<Animator>().SetBool("Game", false);
        }
        cursorLocked = true;
    }

    public void LockCursor(bool delayAnimator)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (delayAnimator)
        {
            StartCoroutine(DelayedAnimator(true));
        } else
        {
            player.GetComponent<Animator>().SetBool("Game", true);
        }
        cursorLocked = false;
    }

    IEnumerator DelayedAnimator(bool lockAnimation)
    {
        yield return new WaitForSeconds(1f);
        player.GetComponent<Animator>().SetBool("Game", lockAnimation);
    }
}
