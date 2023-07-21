using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 10;
    private int currentHealth;
    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Health Reduced by " + damageAmount + "!!!");

        // Play sound or visual effects if desired.

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Trigger the death animation.
        animator.SetBool("IsDeath", true);

        // Disable the player's movement script, so the player cannot move after death.
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Disable the player's collider to avoid further collisions.
        GetComponent<Collider2D>().enabled = false;
    }

    // Add any other health-related functionality here.
}
