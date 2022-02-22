using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void Awake()
    {
        Destroy(CharacterMovement.instance);
        Destroy(GameObject.Find("Main Camera"));
        Destroy(GameManager.instance.player);
        Destroy(ProgressBarScript.instance);
        Destroy(UIController.instance);
        Destroy(TutorialManager.instance);
        Destroy(GameObject.Find("Camera State Controller"));
        Destroy(GameObject.Find("Player UI"));
    }
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.ChangeBackgroundMusic(0);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameManager.instance);
        Destroy(AudioManager.instance);
    }
}
