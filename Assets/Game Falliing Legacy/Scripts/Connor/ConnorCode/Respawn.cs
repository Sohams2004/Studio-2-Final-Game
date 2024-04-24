using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PlayerTut"))
        {
            RespawnPlayer(other.gameObject);
        }
    }

    
    private void RespawnPlayer(GameObject player)
    {
        
        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;

        
    }
}

