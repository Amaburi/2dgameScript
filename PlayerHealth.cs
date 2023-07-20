using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Health Reduced by 1!!!");
        // Play sound or visual effects if desired.

        if (currentHealth <= 0)
        {
            // Call a function to handle player death or game over.
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        // Implement what should happen when the player loses all their hearts.
        // For example, show a game over screen, restart the level, etc.
        // You can also implement a respawn mechanism here.
    }

    // Add any other health-related functionality here.
}
