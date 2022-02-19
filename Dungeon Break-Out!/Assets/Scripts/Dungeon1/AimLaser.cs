using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimLaser : MonoBehaviour
{
    public GameObject child;
    private bool canInteract;
    private bool rotateActive = false;
    private float speed = 0.1f;



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
        // when player is rotating mirror
        if (canInteract == true && InputManager.instance.ePressed && rotateActive == false)
        {
            UIController.instance.DeactivateDialog();
            UIController.instance.ActivateDialog("Use ['W', 'A', 'S', 'D'] keys to aim mirror\nPress ['E'] to exit");
            GameManager.instance.EnableMovement(false);
            rotateActive = true;
            
        }
        // if player deactivates rotating mirror
        else if (canInteract == true && InputManager.instance.ePressed && rotateActive == true)
        {
            rotateActive = false;
            GameManager.instance.EnableMovement(true);
            UIController.instance.DeactivateDialog();
            UIController.instance.ActivateDialog("Press ['E'] to control mirror");
        }

        // controls when rotating mirror
        if (rotateActive == true)
        {
            if (Keyboard.current.wKey.IsPressed())
            {
                child.transform.Rotate(speed, 0, 0);
            }
            if (Keyboard.current.sKey.IsPressed())
            {
                child.transform.Rotate(-speed, 0, 0);
            }
            if (Keyboard.current.aKey.IsPressed())
            {
                child.transform.Rotate(0, 0, speed);
            }
            if (Keyboard.current.dKey.IsPressed())
            {
                child.transform.Rotate(0, 0, -speed);
            }
        }
    }
}
