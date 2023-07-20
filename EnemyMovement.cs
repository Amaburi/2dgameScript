using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float leftBoundary = -2f;
    public float rightBoundary = 2f;

    private bool movingRight = true;
    private float initialX;
    private SpriteRenderer spriteRenderer;
    

    void Start()
    {
        initialX = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        // Calculate the movement vector
        float moveDirection = 0f;
        if (movingRight)
            moveDirection = 1f;
        else
            moveDirection = -1f;

        Vector2 movement = new Vector2(moveSpeed * moveDirection, 0f) * Time.deltaTime;

        // Move the enemy
        transform.Translate(movement);

        // Check if the enemy has reached the boundaries
        if (transform.position.x >= initialX + rightBoundary)
        {
            movingRight = false;
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x <= initialX + leftBoundary)
        {
            movingRight = true;
            spriteRenderer.flipX = true;
        }
    }
}
