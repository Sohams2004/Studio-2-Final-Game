using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class Movement_2D : MonoBehaviour
{
    [SerializeField] public States states;

    [SerializeField] public float movementSpeed, facingDirection;

    [SerializeField] public bool isGrounded, isDoubleJump;

    [SerializeField] public Rigidbody2D playerRb;
    [SerializeField] public CapsuleCollider2D capsuleCollider;



    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        GameObject player = playerRb.gameObject;

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
            states = States.move;
        }

        else if (playerRb.velocity.x == 0)
        {
            states = States.idle;
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
