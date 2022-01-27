using UnityEngine;
using System.IO;
using System.Collections;

public class SavePNG : MonoBehaviour
{
    public RenderTexture rendTex;
    public GameObject[] itemsToPhotograph;

    public void Start()
    {
        StartCoroutine(SaveTexture());
    }

    IEnumerator SaveTexture()
    {
        for (int i = 0; i < itemsToPhotograph.Length; i++)
        {
            itemsToPhotograph[i].SetActive(true);
            yield return new WaitForSeconds(.2f);

            byte[] bytes = toTexture2D(rendTex).EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "/Sprites/" + itemsToPhotograph[i].name + "_Icon" + ".png", bytes);
            itemsToPhotograph[i].SetActive(false);
        }
    }

    Texture2D toTexture2D(RenderTexture rTex)
    {
        //change pixels here if want different image size
        Texture2D tex = new Texture2D(1024, 1024, TextureFormat.ARGB32, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
