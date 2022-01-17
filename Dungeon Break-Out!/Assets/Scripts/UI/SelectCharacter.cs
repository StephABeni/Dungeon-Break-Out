using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    CharacterAppearance appearance;

    // Start is called before the first frame update
    void Start()
    {
        appearance = CharacterAppearance.instance;
    }

    public void ChangeSelection(int direction)
    {
        appearance.ChangeAppearance(direction);
    }
}
