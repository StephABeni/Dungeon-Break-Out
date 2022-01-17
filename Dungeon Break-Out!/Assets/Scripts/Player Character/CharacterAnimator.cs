using UnityEngine;

/* Some code based on Sebastian Graves Youtube tutorial: 
https://www.youtube.com/watch?v=YiNCqmAF3Lc&list=PLD_vBJjpCwJsqpD8QRPNPMfVUpPFLVGg4&index=4
*/
public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    int vertical;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float runSpeed)
    {
        float snappedAnimation;

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
