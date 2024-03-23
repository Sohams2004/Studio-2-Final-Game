using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_2D : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5.0f;

    [SerializeField] Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 playerMove = new Vector2 (horizontal * movementSpeed, 0);
        playerRb.velocity = playerMove;
    }

    private void Update()
    {
        Movement();
    }
}
