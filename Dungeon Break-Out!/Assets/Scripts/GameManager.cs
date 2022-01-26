using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    string currentScene;

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
        } else {
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

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<Animator>().SetBool("Game", false);
    }

    private void LockCursor()
    {
        if (InputManager.instance.tabPressed)
            Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<Animator>().SetBool("Game", true);
    }
}
