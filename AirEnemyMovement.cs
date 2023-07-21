using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float leftBoundary = -5f;
    public float rightBoundary = 2f;

    private bool movingRight = true;
    private float initialX;
    private SpriteRenderer spriteRenderer;
    private bool isDead = false; // Add a flag to track if the enemy is dead.

    void Start()
    {
        initialX = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isDead) // Only move if the enemy is not dead.
        {
            // Calculate the movement vector
            float moveDirection = movingRight ? 1f : -1f;
            Vector3 movement = new Vector3(moveSpeed * moveDirection, 0f, 0f) * Time.deltaTime;

            // Move the enemy
            transform.Translate(movement);

            // Check if the enemy has reached the boundaries and switch movement direction
            if (transform.position.x >= initialX + rightBoundary)
            {
                movingRight = false;
                FlipSprite();
            }
            else if (transform.position.x <= initialX + leftBoundary)
            {
                movingRight = true;
                FlipSprite();
            }
        }
    }

    void FlipSprite()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    // Add a public function to set the enemy as dead (call this from the Die() function in the EnemyController).
    public void SetDead()
    {
        isDead = true;
    }
}
