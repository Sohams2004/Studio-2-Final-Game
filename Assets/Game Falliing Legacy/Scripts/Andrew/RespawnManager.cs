using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private Transform respawnLocation1;
    [SerializeField] private Transform respawnLocation2;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player 1"))
        {
            player1.transform.position = respawnLocation1.transform.position;
            Physics2D.SyncTransforms();
        }
        if (other.CompareTag("Player 2"))
        {
            player2.transform.position = respawnLocation2.transform.position;
            Physics2D.SyncTransforms();
        }
    }
}
