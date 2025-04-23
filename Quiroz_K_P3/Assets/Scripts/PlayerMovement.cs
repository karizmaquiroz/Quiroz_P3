using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float MoveSpeed = 6f;

    public float groundDrag;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGrounded;
    bool grounded;


    Rigidbody playerRB;

    public Transform oreintation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;




    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.freezeRotation = true;
    }
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f, whatIsGrounded);
        MyInput();
        SpeedControl();

        //handle drag
        if (grounded)
            playerRB.linearDamping = groundDrag;
        else
            playerRB.linearDamping = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        //cal movement direction
        moveDirection = oreintation.forward * verticalInput + oreintation.right * horizontalInput;
        playerRB.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVal = new Vector3(playerRB.linearVelocity.x, 0f, playerRB.linearVelocity.z);

        //limit vel 
        if(flatVal.magnitude > MoveSpeed)
        {
            Vector3 limitedVel = flatVal.normalized * MoveSpeed;
            playerRB.linearVelocity = new Vector3(limitedVel.x, playerRB.linearVelocity.y, limitedVel.z);
        }
    }
}
