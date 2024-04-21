using UnityEngine;
using UnityEngine.InputSystem;

public class TestMovement2D : MonoBehaviour
{
    public enum Players
    {
        Player1,
        Player2
    }

    [SerializeField] private int gravityNormal = 4, gravityFalling = 10;
    [SerializeField] public Players players;
    [SerializeField] public States1 states;

    [SerializeField] public float movementSpeed, facingDirection;
    [SerializeField] float rayLength, jumpForce;

    public string horizontalInput;
    public string jumpInput;


    [SerializeField] public bool isGrounded, isDoubleJump;

    [SerializeField] public Rigidbody2D playerRb;
    [SerializeField] public CapsuleCollider2D capsuleCollider;

    public bool stunned;
    int numberOfHits = 0;

    RaycastHit2D groundHit;

    [SerializeField] LayerMask groundLayer;

    [SerializeField] PlayerInput playerInput;

    TestAttack testAttack;

    [SerializeField] public Animator anim;
    [SerializeField] float maxSpeed;

    private float xScale;

    private int ownId;

    public int OwnId { get => ownId; }

    private void Start()
    {


        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        xScale = transform.localScale.x;
        testAttack = FindObjectOfType<TestAttack>();


        playerRb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        playerInput = GetComponent<PlayerInput>();

        /*switch (players)
        {
            case Players.Player1:
                horizontalInput = "Horizontal_P1";
                jumpInput = "Jump_P1";
               
                break;

            case Players.Player2:
                horizontalInput = "Horizontal_P2";
                jumpInput = "Jump_P2";
                
                break;
        }*/
        //SetInput();
    }



    private void SetInput()
    {
        string horizontalAxis = $"Horizontal_P{playerInput.playerIndex + 1}";
        string jumpAxis = $"Jump_P{playerInput.playerIndex + 1}";
        string crouchAxis = $"Crouch_P{playerInput.playerIndex + 1}";
        //string attackInput = $"Fire1_P{playerInput.playerIndex + 1}";
        ownId = playerInput.playerIndex + 1;


        horizontalInput = horizontalAxis;
        jumpInput = jumpAxis;
        testAttack.crouchInput = crouchAxis;
    }


    public void Movement()
    {
        print(horizontalInput);
        float horizontal = Input.GetAxis(horizontalInput);

        if (horizontal > 0)
        {
            facingDirection = 1;
        }

        else if (horizontal < 0)
        {
            facingDirection = -1;
        }

        Vector2 playerMove = new Vector2(horizontal * movementSpeed, 0);
        playerRb.AddForce(playerMove);

        if (playerRb.velocity.magnitude > maxSpeed)
        {
            playerRb.velocity = playerRb.velocity.normalized * maxSpeed;
        }

        if (Mathf.Abs(playerRb.velocity.x) > 0.01f)
        {
            states = States1.move;
            anim.SetBool("Run", true);
        }

        else
        {
            states = States1.idle;
            anim.SetBool("Run", false);
            anim.SetBool("Jump", false);
        }

        if (playerRb.velocity.x < -.01f)
        {
            transform.localScale = new Vector2(-transform.localScale.y, transform.localScale.y);
        }

        else if (playerRb.velocity.x > .01f)
        {
            transform.localScale = new Vector2(transform.localScale.y, transform.localScale.y);
        }

    }

    public void GroundCheck()
    {
        groundHit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        if (groundHit)
        {
            Debug.Log("Grounded");
            isGrounded = true;
        }

        if (!groundHit)
        {
            Debug.Log("Not grounded");
            isGrounded = false;
        }
    }

    public void Jump()
    {


        if (Input.GetButtonDown(jumpInput))
        {
            print(jumpInput);
            if (isGrounded)
            {
                print("force it up");

                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        if (playerRb.velocity.y > .1f)
        {
            states = States1.jump;
            anim.SetBool("Jump", true);
        }
        else
        {
            states = States1.idle;

            anim.SetBool("Jump", false);

        }

        if (playerRb.velocity.y < -0.1f)
        {

            playerRb.gravityScale = gravityFalling;
            anim.SetBool("Fall", true);


            //playerRb.AddForce(Physics2D.gravity * playerRb.gravityScale * playerRb.mass);
        }
        else
        {
            playerRb.gravityScale = gravityNormal;
            anim.SetBool("Fall", false);

        }




    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.down * rayLength);
    }

    private void Update()
    {
        Movement();
        Jump();
        GroundCheck();
    }
}

