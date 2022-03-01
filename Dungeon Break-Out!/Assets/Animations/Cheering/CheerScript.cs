using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerScript : MonoBehaviour
{
    public Animator anim;

    void Awake() {
        anim = gameObject.GetComponent<Animator>();
    }

    IEnumerator Start() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(3, 10));
            anim.SetInteger("type", Random.Range(0, 3));
            anim.SetTrigger("cheer");
        }
    }
}
