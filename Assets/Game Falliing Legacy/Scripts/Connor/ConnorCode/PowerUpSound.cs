using UnityEngine;

public class PowerUpSound : MonoBehaviour
{
    public AudioClip powerUpSound;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !triggered)
        {

            if (powerUpSound != null)
            {

                AudioSource.PlayClipAtPoint(powerUpSound, transform.position);
            }
            else
            {
                Debug.LogWarning("Power-up sound effect is not assigned!");
            }

            triggered = true;

        }
    }
}



