using UnityEngine;
using UnityEngine.SceneManagement;

/* Some code based on Sebastian Graves Youtube tutorials: 
https://www.youtube.com/watch?v=suU4aBdBjKA&list=PLD_vBJjpCwJsqpD8QRPNPMfVUpPFLVGg4&index=3
https://www.youtube.com/watch?v=dJPnqv2IOTE&list=PLD_vBJjpCwJsqpD8QRPNPMfVUpPFLVGg4&index=7
*/
public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement instance;
    InputManager inputManager;
    public LayerMask groundLayer;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidBody;

    public float walkSpeed = 4;
    public float runSpeed = 8;
    public float rotationSpeed = 15;

    public GameObject telekinesisFollow;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else
        {
            if (instance != this)
            {
                Debug.Log("Multiple CharacterMovement Instances.");
                Destroy(this);
            }
        }
    }

    private void Start()
    {
        inputManager = InputManager.instance;
        playerRigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    private void Update()
    {
        inputManager.HandleMovementInput();
    }

    public void HandleAllMovement()
    {
        MoveCharacter();
        RotateCharacter();
    }

    private Vector3 MovementSetup(Vector3 direction)
    {
        //move character forward/backwards in the direction the camera is facing
        direction = cameraObject.forward * inputManager.verticalInput;
        //move character side to side in relation to camera direction
        direction += cameraObject.right * inputManager.horizontalInput;
        //keep values somewhat consistent with normalize
        direction.Normalize();
        //make sure they don't float off into the sky
        direction.y = 0;
        return direction;
    }

    private void MoveCharacter()
    {
        Vector3 charMovement = MovementSetup(moveDirection);    
        charMovement *= inputManager.shiftPressed ? runSpeed : walkSpeed; //adjust character speed on the fly
        playerRigidBody.velocity = charMovement;
    }

    private void RotateCharacter()
    {
        if (inputManager.rightMousePressed)
        {
            //Horizontal rotation, move entire avatar
            Quaternion desiredRotation = transform.rotation * Quaternion.AngleAxis(inputManager.lookInput.x, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 50f * Time.deltaTime);

            //vertical rotation, move only telekinesis follow
            //telekinesisFollow.transform.rotation *= Quaternion.AngleAxis(-inputManager.lookInput.y, Vector3.right);
            desiredRotation = telekinesisFollow.transform.rotation * Quaternion.AngleAxis(-inputManager.lookInput.y, Vector3.right);
            telekinesisFollow.transform.rotation = Quaternion.Slerp(telekinesisFollow.transform.rotation, desiredRotation, 50f * Time.deltaTime);


            Vector3 angles = telekinesisFollow.transform.localEulerAngles;
            angles.z = 0;

            float angle = telekinesisFollow.transform.localEulerAngles.x;

            //Clamp the Up/Down rotation
            if (angle > 180 && angle < 320)
            {
                angles.x = 320;
            }
            else if (angle < 180 && angle > 50)
            {
                angles.x = 50;
            }

            telekinesisFollow.transform.localEulerAngles = angles;
        }
        else
        {
            Vector3 rotateDirection = MovementSetup(Vector3.zero);

            //Leave character facing the direction you controlled them to face
            if (rotateDirection == Vector3.zero) rotateDirection = transform.forward;

            Quaternion desiredRotation = Quaternion.LookRotation(rotateDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void SetCurrentPosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }
}
