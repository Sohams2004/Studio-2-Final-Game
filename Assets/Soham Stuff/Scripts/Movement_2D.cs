using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_2D : MonoBehaviour
{
    [SerializeField] public States states;

    [SerializeField] float movementSpeed = 5.0f;

    [SerializeField] public bool isGrounded, isDoubleJump;

    [SerializeField] public Rigidbody2D playerRb;
    [SerializeField] public CapsuleCollider2D capsuleCollider;



    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

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
    }
}
