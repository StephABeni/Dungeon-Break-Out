using UnityEngine;

/* Some code based on Sebastian Graves Youtube tutorial: 
https://www.youtube.com/watch?v=YiNCqmAF3Lc&list=PLD_vBJjpCwJsqpD8QRPNPMfVUpPFLVGg4&index=4
*/
public class CharacterAnimator : MonoBehaviour
{
    public static CharacterAnimator instance;
    public Animator animator;
    int vertical;
    public float snappedAnimation;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple CharacterAnimator Instances.");
                Destroy(this);
            }
        }

        animator = GetComponent<Animator>();
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float runSpeed)
    {
        if (runSpeed > 0f && InputManager.instance.shiftPressed)  {
            snappedAnimation = 2f;
        } else if (runSpeed > 0 && runSpeed <= 1f) {
            snappedAnimation = 1f;
        } else {
            snappedAnimation = 0f;
        }
        animator.SetFloat(vertical, snappedAnimation, 0.1f, Time.deltaTime);
    }
}
