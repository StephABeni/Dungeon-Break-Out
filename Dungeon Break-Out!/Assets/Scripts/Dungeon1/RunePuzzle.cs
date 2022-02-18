using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePuzzle : MonoBehaviour
{
    public static RunePuzzle instance;
    public List<RuneShelf> runeData = new List<RuneShelf> ( new RuneShelf[8]);
    private int count;
    public bool puzzleComplete = false;
    public GameObject target;
    public GameObject dustFX;
    public GameObject[] runes;
    public Animator runeAnimator;
    public Animator shelfAnimator;
    public Animator targetAnimator;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }

    // hide traget until puzzle is completed
    void Start()
    {
        //target.GetComponent<MeshRenderer>().enabled = false;
        count = 0;

        dustFX.SetActive(false);
        runes = GameObject.FindGameObjectsWithTag("Rune");

    }

    // check if puzzle is completed
    void Update()
    {
        if (puzzleComplete != true)
        {
            count = 0;
            for (int i = 0; i < 8; i++)
            {
                if (runeData[i].correct)
                {
                    count++;
                }
            }
            // puzzle comlpete
            if (count == 8)
            {
                puzzleComplete = true;
                EndPuzzle();
            }
        }
    }

    void EndPuzzle()
    {
        //target.GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine(DelayCode());
        
        foreach (GameObject child in runes)
        {
            StartCoroutine(FadeOutMaterial(5f, child));
            
        }
    }
    // https://stackoverflow.com/questions/54042904/how-to-fade-out-disapear-a-gameobject-slowly
    IEnumerator FadeOutMaterial(float fadeSpeed, GameObject child)
    {
        Debug.Log(child.name);
        Renderer rend = child.gameObject.transform.GetComponent<Renderer>();
        Color matColor = rend.material.color;
        float alphaValue = rend.material.color.a;

        while (rend.material.color.a > 0f)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
        child.gameObject.SetActive(false);
    }

    IEnumerator DelayCode()
    {
        yield return new WaitForSeconds(2f);
        dustFX.SetActive(true);
        runeAnimator.SetTrigger("runeDisappear");
        shelfAnimator.SetTrigger("shelfDisappear");
        targetAnimator.SetTrigger("showTarget");
    }
}
