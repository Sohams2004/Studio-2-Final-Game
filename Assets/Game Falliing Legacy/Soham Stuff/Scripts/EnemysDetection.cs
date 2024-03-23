using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysDetection : MonoBehaviour
{
    RaycastHit2D playerDetectHit;
    [SerializeField] LayerMask playerLayer;

    [SerializeField] float rayLength;

    private void Start()
    {
    }

    void DetectPlayer()
    {
        playerDetectHit = Physics2D.Raycast(transform.position, Vector2.left, rayLength, playerLayer);

        if (playerDetectHit)
        {
            Debug.Log("Player Detected");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.left * rayLength);
    }

    private void Update()
    {
        DetectPlayer();
    }
}
