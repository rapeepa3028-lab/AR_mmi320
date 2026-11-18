
using UnityEngine;

public class CardDetector : MonoBehaviour
{
    public int cardNumber;

    private GameManager gameManager;
    private bool isTracked = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnTargetFound()
    {
        // Ignore duplicate detection while this card is tracked
        if (isTracked) return;

        isTracked = true;

        if (gameManager != null)
        {
            gameManager.PlayTreatment(cardNumber);
        }
    }

    public void OnTargetLost()
    {
        // Allow this card to be played again after it disappears
        isTracked = false;
    }
}
