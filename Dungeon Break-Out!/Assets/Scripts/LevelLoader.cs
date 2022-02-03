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
        if (currentScene != "StartPage" && currentScene != "CharacterSelect" && inputManager.escapePressed)
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

    public void ChangeMusic(int song)
    {
        StartCoroutine(DelayMusicChange(song));
    }

    IEnumerator DelayLevelLoad(string sceneName)
    {
        crossfade.SetTrigger("StartFade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator DelayMusicChange(int song)
    {
        yield return new WaitForSeconds(1f);
        AudioManager.instance.ChangeBackgroundMusic(song);
    }
}
