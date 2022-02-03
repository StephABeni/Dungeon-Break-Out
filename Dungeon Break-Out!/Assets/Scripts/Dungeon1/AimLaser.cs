using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLaser : MonoBehaviour
{
    public GameObject child;
    private GameObject MainCamera;
    private bool canInteract;
    private bool rotateActive = false;
    private float Speed = 0.5f;

    private void Awake()
    {
        MainCamera = GameObject.Find("Main Camera");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = true;
            UIController.instance.ActivateDialog("[Press 'E'] to control mirror");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIController.instance.DeactivateDialog();
            canInteract = false;
            rotateActive = false;
            GameManager.instance.EnableMovement(true);
        }
    }

    private void FixedUpdate()
    {
        if (canInteract == true && InputManager.instance.ePressed && rotateActive == false)
        {
            UIController.instance.DeactivateDialog();
            GameManager.instance.EnableMovement(false);
            rotateActive = true;
            
        } else if (canInteract == true && InputManager.instance.ePressed && rotateActive == true)
        {
            rotateActive = false;
            child.transform.SetParent(null);
            GameManager.instance.EnableMovement(true);
            UIController.instance.ActivateDialog("[Press 'E'] to control mirror");
        }
        if (rotateActive == true)
        {
            //https://forum.unity.com/threads/rotate-gameobject-to-where-camera-is-facing.501460/
            child.transform.rotation = Quaternion.Lerp(child.transform.rotation, MainCamera.transform.rotation, Speed * Time.deltaTime);
        }
    }
}