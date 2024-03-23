using UnityEngine;
//using UnityEngine.Windows;

public class Movement_2D : MonoBehaviour
{
    [SerializeField] public States1 states;

    [SerializeField] public float movementSpeed, facingDirection;

    [SerializeField] public bool isGrounded, isDoubleJump;

    [SerializeField] public Rigidbody2D playerRb;
    [SerializeField] public CapsuleCollider2D capsuleCollider;

    [SerializeField] public Animator anim;

    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            facingDirection = 1;
        }

        else if (horizontal < 0)
        {
            facingDirection = -1;
        }

        Vector2 playerMove = new Vector2(horizontal * movementSpeed, playerRb.velocity.y);
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
}
