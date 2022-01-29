using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public string sceneName;
    public Vector3 spawnLocation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Collide");
            SceneManager.LoadScene(sceneName);
            CharacterMovement.instance.SetCurrentPosition(spawnLocation);
        }
    }
}
