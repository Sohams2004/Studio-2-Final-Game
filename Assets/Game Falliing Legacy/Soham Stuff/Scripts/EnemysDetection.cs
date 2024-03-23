using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysDetection : EnemyMove
{
    RaycastHit2D playerDetectHit;
    [SerializeField] LayerMask playerLayer;

    [SerializeField] float rayLength;

    [SerializeField] Vector2 rayDirection;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void DetectPlayer()
    {
        playerDetectHit = Physics2D.Raycast(transform.position, rayDirection, rayLength, playerLayer);

        if (playerDetectHit)
        {
            Debug.Log("Player Detected");
        }

        if (pointIndex == 1)
        {
            rayDirection = Vector2.right;
        }

        else if (pointIndex == 0)
        {
            rayDirection = Vector2.left;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, rayDirection * rayLength);
    }

    private void Update()
    {
        DetectPlayer();
        EnemyPatrol();
    }
}
