using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator crossfade;
    public InputManager inputManager;
    public string currentScene;

    public void Start()
    {
        inputManager = InputManager.instance;
        currentScene = SceneManager.GetActiveScene().name;
    }
    public void Update()
    {
        if (currentScene == "Game" && inputManager.escapePressed)
            QuitGame();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(DelayLevelLoad(sceneName));
    }

    IEnumerator DelayLevelLoad(string sceneName)
    {
        crossfade.SetTrigger("StartFade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
