using UnityEngine;

public class PatientDetector : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnTargetFound()
    {
        if (gameManager != null)
        {
            gameManager.SelectRandomCase();
        }
    }
}