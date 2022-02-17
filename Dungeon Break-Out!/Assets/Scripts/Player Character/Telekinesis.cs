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
    public GameObject FX;
    public GameObject instantiatedFX;
    public LayerMask TKLayer;


    private void Start()
    {
        inputManager = InputManager.instance;
        cameraObject = Camera.main.transform;
    }

    void FixedUpdate()
    {
        if (inputManager.rightMousePressed) {
            stateDrivenCamera.Play("Telekinesis");
            if(currentlyHeldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(cameraObject.position, cameraObject.forward, out hit, pickUpRange, TKLayer))
                {
                    if (!instantiatedFX)
                    {
                        instantiatedFX = Instantiate(FX, hit.transform);
                    }
                    if (inputManager.ePressed)
                    {
                        StartCoroutine(DelayInteraction(hit.transform.gameObject));
                    }
                } else {
                    if (instantiatedFX)
                    {
                        Destroy(instantiatedFX);
                        instantiatedFX = null;
                    }
                }
            } else {
                MoveObject();
                if (inputManager.ePressed)
                {
                    StartCoroutine(DelayInteraction(null));
                }
            }
        } else {
            stateDrivenCamera.Play("Player Freelook");
            if (currentlyHeldObject) {
                DropObject();
                Destroy(instantiatedFX);
                instantiatedFX = null;
            }
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
