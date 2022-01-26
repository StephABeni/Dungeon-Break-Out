using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public GameObject player;
    string currentScene;

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
        if (currentScene != "CharacterSelect")
        {
            if (InputManager.instance.tabPressed)
                UnlockCursor();
            else
                LockCursor();
        }
        else
        {
            UnlockCursor();
        }
    }

    private void FixedUpdate()
    {
        if(currentScene != "CharacterSelect" && !InputManager.instance.tabPressed)
        {
            CharacterMovement.instance.HandleAllMovement();
        }
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<Animator>().SetBool("Game", false);
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<Animator>().SetBool("Game", true);
    }

    //Used only when starting game, so animation switch isn't noticable
    public void DelayedLockFunc()
    {
        StartCoroutine(DelayedLock());
    }

    IEnumerator DelayedLock()
    {
        yield return new WaitForSeconds(1f);
        LockCursor();
    }
}
