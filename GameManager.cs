using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectCoin(int value)
    {
        score += value;
        // You can also update the UI to display the current score.
        Debug.Log("Coins collected: " + score);
    }
}
