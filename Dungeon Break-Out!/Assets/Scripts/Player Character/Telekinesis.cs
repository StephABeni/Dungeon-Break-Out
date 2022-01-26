using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    public float pickUpRange = 12f;
    public Transform holdParent;
    public GameObject currentlyHeldObject;
    InputManager inputManager;
    Transform cameraObject;
    public Animator stateDrivenCamera;
    public float moveForce = 150f;


    private void Start()
    {
        inputManager = InputManager.instance;
        cameraObject = Camera.main.transform;
    }

    void FixedUpdate()
    {
        if (inputManager.rightMousePressed) {
            stateDrivenCamera.Play("Telekinesis");
            if(inputManager.ePressed) {
                if (currentlyHeldObject == null) {
                    RaycastHit hit;
                    if (Physics.Raycast(cameraObject.position, cameraObject.forward, out hit, pickUpRange))
                    {
                        Debug.Log("E Pressed. Hit Object: " + hit.transform.gameObject.name);
                        StartCoroutine(DelayInteraction(hit.transform.gameObject));
                    }
                } else {
                    StartCoroutine(DelayInteraction(null));
                }
            }
            if (currentlyHeldObject) {
                MoveObject();
            }
        } else {
            stateDrivenCamera.Play("Player Freelook");
        }
    }

    IEnumerator DelayInteraction(GameObject obj)
    {
        yield return new WaitForSeconds(0.1f);
        if(obj != null)
        {
            PickUpObject(obj);
        } else
        {
            DropObject();
        }
    }

    void PickUpObject(GameObject pickUpObject)
    {
        if (pickUpObject.GetComponent<Rigidbody>())
        {
            Rigidbody objRB = pickUpObject.GetComponent<Rigidbody>();
            objRB.useGravity = false;
            objRB.drag = 10;
            objRB.transform.parent = holdParent;
            currentlyHeldObject = pickUpObject;
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(currentlyHeldObject.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 movedirection = (holdParent.position - currentlyHeldObject.transform.position);
            currentlyHeldObject.GetComponent<Rigidbody>().AddForce(movedirection * moveForce);
        }
    }

    void DropObject()
    {
        if (currentlyHeldObject) {
            Rigidbody objRB = currentlyHeldObject.GetComponent<Rigidbody>();
            objRB.useGravity = true;
            objRB.drag = 1;
            objRB.transform.parent = null;
            currentlyHeldObject = null;
        }
    }
}
