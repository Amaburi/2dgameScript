using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMPro.TextMeshProUGUI coinText; // Reference to the "Coin" TextMeshProUGUI component in the Canvas.

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
        coinText.text =  score.ToString();
        // You can also update the UI to display the current score.
        Debug.Log("Coins collected: " + score);
    }

}
