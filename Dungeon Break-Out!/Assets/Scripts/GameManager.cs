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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.GetComponent<Animator>().SetBool("Game", true);
        } else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.GetComponent<Animator>().SetBool("Game", false);
        }          
    }

    private void FixedUpdate()
    {
        if(currentScene != "CharacterSelect")
        {
            CharacterMovement.instance.HandleAllMovement();
        }
    }
}
