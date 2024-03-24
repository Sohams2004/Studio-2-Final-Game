using UnityEngine;
public class PlayerJump : Movement_2D
{
    RaycastHit2D groundHit;

    [SerializeField] LayerMask groundLayer;

    [SerializeField] float rayLength, jumpForce;

    public string jumpInput;

    private void Start()
    {
     
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
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            }
        }

        if (Input.GetButtonUp(jumpInput) && playerRb.velocity.y > 0)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);

        }

        if (playerRb.velocity.y < -0.1f)
        {
            //anim.SetFloat("Movement", playerRb.velocity.y);
            playerRb.AddForce(Physics2D.gravity * playerRb.gravityScale * playerRb.mass);

        }

        if (playerRb.velocity.y != 0)
        {
            states = States1.jump;
            //anim.SetBool("Jump", true);
        }

        else if (playerRb.velocity.y == 0 && playerRb.velocity.x == 0)
        {
            states = States1.idle;
            //anim.SetBool("Jump", false);
            //anim.SetBool("Fall", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.down * rayLength);
    }
}
