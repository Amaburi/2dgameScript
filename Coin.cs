using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip coinCollectSound; // Reference to the coin collection sound.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the coin collection sound directly from the AudioClip
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);

            // You can also add other behavior here, like updating the score.
            GameManager.Instance.CollectCoin(coinValue);

            Destroy(gameObject);
        }
    }
}
