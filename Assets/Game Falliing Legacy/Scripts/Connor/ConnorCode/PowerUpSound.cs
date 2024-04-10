using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSound : MonoBehaviour
{
    public AudioClip powerUpSound; // Sound effect for the power-up

    private bool triggered = false; // To prevent multiple triggering

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is tagged as "Player" and the power-up hasn't been triggered yet
        if (other.CompareTag("Player") && !triggered)
        {
            // Check if the power-up sound effect is assigned
            if (powerUpSound != null)
            {
                // Play the power-up sound effect
                AudioSource.PlayClipAtPoint(powerUpSound, transform.position);
            }
            else
            {
                Debug.LogWarning("Power-up sound effect is not assigned!");
            }

            triggered = true; // Set triggered to true to prevent multiple triggering
            // You might want to add additional logic here such as applying power-up effects to the player
            // For example: ApplyPowerUpEffects();
        }
    }

    // Additional logic for applying power-up effects to the player can be implemented here
    // void ApplyPowerUpEffects()
    // {
    //     // Apply power-up effects to the player
    // }
}
