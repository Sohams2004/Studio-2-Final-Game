using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockbackForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is an enemy (or any object you want to apply knockback to)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Calculate the knockback direction (opposite to the player's position)
            Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;

            // Apply knockback force to the colliding object
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // Reset velocity
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
