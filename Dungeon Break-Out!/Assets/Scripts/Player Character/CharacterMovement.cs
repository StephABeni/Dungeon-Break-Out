using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Cinemachine;

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
    public CinemachineFreeLook thirdPersonCam;
    Rigidbody playerRigidBody;

    [Header("Movement Speeds")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    public float rotationSpeed = 15f;

    [Header("Gravity")]
    public float gravity;
    public float inAirTimer;

    private float distToGround;
    private bool gravityDown;
    //private Vector3 gravityMovement;
    public GameObject telekinesisFollow;

    private bool viewSwitched;

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

        gravityDown = true;
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
        HandleGravity();
    }

    private bool IsGrounded()
    {
        if (gravityDown)
            return Physics.Raycast(transform.position + new Vector3(0f, 0.02f, 0f), Vector3.down, .15f);
        else
            return Physics.Raycast(transform.position + new Vector3(0f, 0.02f, 0f), Vector3.up, .15f);
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

    private void HandleGravity()
    {
        if (!IsGrounded())
        {
            //Debug.Log("My Pos:" + gameObject.transform.position);

            inAirTimer += .1f;

            Vector3 newPos;
            if (gravityDown)
                newPos = gameObject.transform.position +  new Vector3(0, -gravity* inAirTimer, 0);// (gravityDirection * gravity * inAirTimer);
            else
                newPos = gameObject.transform.position + new Vector3(0, gravity * inAirTimer, 0);// (gravityDirection * gravity * inAirTimer);

            SetCurrentPosition(newPos, false);
            //Debug.Log("New Pos:" + newPos);
        }
        else
        {
            inAirTimer = 0;
        }
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
            viewSwitched = true;
            //Horizontal rotation, move entire avatar
            Quaternion desiredRotation = transform.rotation * Quaternion.AngleAxis(inputManager.lookInput.x, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

            //vertical rotation, move only telekinesis follow
            desiredRotation = telekinesisFollow.transform.rotation * Quaternion.AngleAxis(-inputManager.lookInput.y, Vector3.right);
            telekinesisFollow.transform.rotation = Quaternion.Slerp(telekinesisFollow.transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);


            Vector3 angles = telekinesisFollow.transform.localEulerAngles;
            angles.z = 0;

            float angle = telekinesisFollow.transform.localEulerAngles.x;

            //Clamp the Up/Down rotation
            if (angle > 180 && angle < 320) { angles.x = 320; }
            else if (angle < 180 && angle > 50) { angles.x = 50; }

            telekinesisFollow.transform.localEulerAngles = angles;
        } else {
            if (viewSwitched) {
                thirdPersonCam.m_Heading.m_Definition = CinemachineOrbitalTransposer.Heading.HeadingDefinition.TargetForward;
                thirdPersonCam.m_RecenterToTargetHeading.m_enabled = true;
                thirdPersonCam.m_YAxisRecentering.m_enabled = true;
                viewSwitched = false;
            }
            StartCoroutine(DelayCameraChange());

            Vector3 rotateDirection = MovementSetup(Vector3.zero);

            //Leave character facing the direction you controlled them to face
            if (rotateDirection == Vector3.zero) rotateDirection = transform.forward;

            Quaternion desiredRotation = Quaternion.LookRotation(rotateDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void SetCurrentPosition(Vector3 position, bool delayChange)
    {
        if (!delayChange)
            gameObject.transform.position = position;
        else
            StartCoroutine(DelayPositionChange(position));
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    IEnumerator DelayPositionChange(Vector3 position)
    {
        yield return new WaitForSeconds(0.9f);
        Debug.Log("Changing Position");
        gameObject.transform.position = position;
    }

    IEnumerator DelayCameraChange() {
        yield return new WaitForSeconds(0.05f);
        thirdPersonCam.m_Heading.m_Definition = CinemachineOrbitalTransposer.Heading.HeadingDefinition.WorldForward;
        thirdPersonCam.m_RecenterToTargetHeading.m_enabled = false;
        thirdPersonCam.m_YAxisRecentering.m_enabled = false;
    }
}
