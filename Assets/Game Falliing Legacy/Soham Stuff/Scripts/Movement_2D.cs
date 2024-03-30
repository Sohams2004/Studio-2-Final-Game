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



    [SerializeField] public Players players;
    [SerializeField] public States1 states;

    [SerializeField] public float movementSpeed, facingDirection;
    public string horizontalInput;

    [SerializeField] public bool isGrounded, isDoubleJump;

    [SerializeField] public Rigidbody2D playerRb;
    [SerializeField] public CapsuleCollider2D capsuleCollider;

    [SerializeField] public Animator anim;
    private Vector2 movementInput = Vector2.zero;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
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

}




