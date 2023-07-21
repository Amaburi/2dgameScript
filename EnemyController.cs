using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform.
    public float movementSpeed = 3f;  // Speed at which the enemy follows the player.
    public float followDistance = 5f; // Distance at which the enemy starts following the player.
    public int damageAmount = 1;      // Damage the enemy will deal to the player.

    private bool isFollowingPlayer = false;
    private float attackDistance = 1.5f; // Distance at which the enemy can attack the player.
    private Animator animator;
    private bool isDead = false;
    public AirEnemyMovement airEnemyMovement;
    public GameObject backCollider; // Reference to the trigger collider on the enemy's back.

    private void Start()
    {
        animator = GetComponent<Animator>();
        airEnemyMovement = GetComponent<AirEnemyMovement>();
    }

    private void Update()
    {
        if (!isDead && playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= followDistance)
            {
                isFollowingPlayer = true;
                FollowPlayer();
            }
            else
            {
                isFollowingPlayer = false;
            }

            if (isFollowingPlayer && distanceToPlayer <= attackDistance)
            {
                // Call the AttackPlayer function only when the player is within the attackDistance.
                AttackPlayer();
            }
        }
    }

    private void FollowPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    private void AttackPlayer()
    {
        PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }

    private void Die()
    {
        // Trigger the death animation.
        isDead = true;
        animator.SetBool("IsDeath", true);

        // Disable the collider to avoid further collisions.
        GetComponent<Collider2D>().enabled = false;

        // Stop the enemy's movement.
        airEnemyMovement.SetDead();

        // Add any other actions you want to happen when the enemy dies.
    }

    // OnTriggerEnter2D is called when a Collider2D enters the trigger collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Player"))
        {
            // If the player collides with the back collider, call the Die function to kill the enemy.
            Die();
        }
    }
}
