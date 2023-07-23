using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 10;
    private int currentHealth;
    private Animator animator;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameoverText;
    public AudioClip coinCollectSound;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        gameoverText.gameObject.SetActive(false);
        UpdateLivesText();
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
        UpdateLivesText();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            CollectHeart(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
    private void CollectHeart(GameObject heart)
    {
        currentHealth++;
        // Play sound or visual effects if desired.
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
        Debug.Log("collected the heart");
        // Destroy the heart GameObject after collecting it.
        Destroy(heart);
        UpdateLivesText();
    }
    private void Die()
    {
        // Trigger the death animation.
        
        animator.SetBool("IsDeath", true);
        
        Debug.Log("Game Over text set active!");
        // Disable the player's movement script, so the player cannot move after death.
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Disable the player's collider to avoid further collisions.
        GetComponent<Collider2D>().enabled = false;
        gameoverText.gameObject.SetActive(true);


    }

    // Add any other health-related functionality here.
    private void UpdateLivesText()
    {
        livesText.text = currentHealth.ToString();
    }
}
