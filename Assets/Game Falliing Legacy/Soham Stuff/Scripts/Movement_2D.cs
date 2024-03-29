using UnityEngine;
using UnityEngine.InputSystem;

//using UnityEngine.Windows;

public class Movement_2D : MonoBehaviour
{
    public enum Players
    {
        Player1,
        Player2
    }

    [SerializeField]  Players players;
    [SerializeField]  States1 states;

    [SerializeField]  float movementSpeed;
    [SerializeField] public float facingDirection;
    public string horizontalInput;

    [SerializeField]  bool isGrounded, isDoubleJump;
    [SerializeField] bool block = false;
    [SerializeField] bool jump = false;

    [SerializeField]  Rigidbody2D playerRb;
    [SerializeField]  CapsuleCollider2D capsuleCollider;

    [SerializeField] public Animator anim;
    private Vector2 movementInput = Vector2.zero;

    public string crouchInput;
    private Attack attack;

    RaycastHit2D groundHit;

    [SerializeField] LayerMask groundLayer;

    [SerializeField] float rayLength, jumpForce;

    public string jumpInput;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        /*switch (players)
        {
            case Players.Player1:
                horizontalInput = "Horizontal_P1";
                jumpInput = "Jump_P1";
                crouchInput = "Crouch_P1";
                attackInput = "Fire1_P1";
                break;

            case Players.Player2:
                horizontalInput = "Horizontal_P2";
                jumpInput = "Jump_P2";
                crouchInput = "Crouch_P2";
                attackInput = "Fire2_P2";
                break;
        }*/
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.action.triggered;
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        block = context.action.triggered;
    }

    public void Movement()
    {
        if (movementInput.x > 0)
        {
            facingDirection = 1;
        }

        else if (movementInput.x < 0)
        {
            facingDirection = -1;
        }

        Vector2 playerMove = new Vector2(movementInput.x * movementSpeed, playerRb.velocity.y);
        playerRb.velocity = playerMove;

        if (playerRb.velocity.x != 0)
        {
            states = States1.move;
            anim.SetBool("Run", true);
        }

        else if (playerRb.velocity.x == 0)
        {
            states = States1.idle;
            anim.SetBool("Run", false);
        }

        if (transform.localScale.x > 0 && playerRb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        else if (transform.localScale.x < 0 && playerRb.velocity.x > 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    public void Block()
    {
        if (block)
        {
            if (isGrounded)
            {
                anim.SetBool("Block", true);
                if (attack != null)
                {
                    attack.repulseForce = 0;
                }
            }
        }

        else
        {
            if (isGrounded || !isGrounded)
            {
                anim.SetBool("Block", false);
            }
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
        if (jump)
        {
            if (isGrounded)
            {
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            }
        }

        if (Input.GetButtonUp(jumpInput) && playerRb.velocity.y > 0)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);

        }

        if (playerRb.velocity.y < -0.1f)
        {
            anim.SetFloat("Movement", playerRb.velocity.y);
            playerRb.AddForce(Physics2D.gravity * playerRb.gravityScale * playerRb.mass);

        }

        if (playerRb.velocity.y != 0)
        {
            states = States1.jump;
            anim.SetBool("Jump", true);
        }

        else if (playerRb.velocity.y == 0 && playerRb.velocity.x == 0)
        {
            states = States1.idle;
            anim.SetBool("Jump", false);
        }
    }


    private void Update()
    {
        Block();
        Jump();
        GroundCheck();
        Movement();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.down * rayLength);
    }
}


