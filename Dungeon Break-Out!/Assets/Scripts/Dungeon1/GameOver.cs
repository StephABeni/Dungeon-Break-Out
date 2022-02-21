using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(CharacterMovement.instance);
        Destroy(GameObject.Find("Main Camera"));
        Destroy(GameManager.instance.player);
        Destroy(ProgressBarScript.instance);
        Destroy(UIController.instance);
        Destroy(TutorialManager.instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        Destroy(GameManager.instance);
    }
}
