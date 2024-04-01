/*using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float Speed = 5f;
    public float Height = 10f;
    public Transform TouchFloor;
    public LayerMask GroundChecker;
    public GroundCheck groundCheck;
    private Animator anim;
    private bool rolling = false;
    private Rigidbody2D rb;
    [SerializeField] bool isGrounded = false;
    private int direction;
    [SerializeField] float delayToIdle = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    private void Update()
    {
        if (!rolling)

            Move();
        JumpFall();

    }
    public void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); ;
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        anim.SetFloat("Movement", rb.velocity.y);
        if (moveInput > 0 || moveInput < 0)
        {

            anim.SetBool("Run", true);
        }
        else
        {
            moveInput = 0;
            anim.SetBool("Run", false);
            anim.SetBool("Jump", false);

        }
        if (moveInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            direction = -1;

        }
        else if (moveInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            direction = 1;

        }

    }
    public void JumpFall()
    {
        float jumpinput = Input.GetAxis("Vertical");

        if (jumpinput > 0 || jumpinput < 0 && isGrounded && !rolling)
        {
            isGrounded = false;
            anim.SetBool("Jump", true);
            anim.SetBool("IsGrounded", isGrounded);
            rb.velocity = new Vector2(rb.velocity.x, Height);
            groundCheck.Disable(0.2f);

        }
        if (!isGrounded && groundCheck.State())
        {
            isGrounded = true;
            anim.SetBool("IsGrounded", isGrounded);

        }

        if (isGrounded && !groundCheck.State())
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", isGrounded);

        }
    }
    public void OnMove(InputAction.CallbackContext ctx) => rb.velocity = ctx.ReadValue<Vector2>();
}
*/