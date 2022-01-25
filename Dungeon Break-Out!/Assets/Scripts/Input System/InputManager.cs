using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    PlayerMovement playerMovement;
    CharacterAnimator characterAnimator;

    public Vector2 movementInput;
    public Vector2 lookInput;
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;
    public bool escapePressed;
    public bool shiftPressed;
    public bool ePressed;
    public bool leftMousePressed;
    public bool rightMousePressed;

    private void Awake()
    {
        if (instance == null) instance = this;
        else {
            if (instance != this)
            {
                Debug.Log("Multiple InputManager Instances.");
                Destroy(this);
            }
        }
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    private void OnEnable()
    {
        if (playerMovement == null)
        {
            playerMovement = new PlayerMovement();
            playerMovement.Movement.Move.performed += i => movementInput = i.ReadValue<Vector2>();
            playerMovement.Mouse.MouseLook.performed += i => lookInput = i.ReadValue<Vector2>();

            playerMovement.Movement.Run.performed += i => shiftPressed = true;
            playerMovement.Movement.Run.canceled += i => shiftPressed = false;

            playerMovement.Menu.EscapeKey.performed += i => escapePressed = true;
            playerMovement.Menu.EscapeKey.canceled += i => escapePressed = false;

            playerMovement.Interaction.E.performed += i => ePressed = true;
            playerMovement.Interaction.E.canceled += i => ePressed = false;

            playerMovement.Interaction.RBPickup.performed += i => leftMousePressed = !leftMousePressed;
            playerMovement.Interaction.Telekinesis.performed += i => rightMousePressed = !rightMousePressed;
        }

        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    public void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        characterAnimator.UpdateAnimatorValues(moveAmount);
    }
}
