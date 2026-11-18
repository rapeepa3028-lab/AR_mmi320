
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Treatment sequences
    private int[] case1Sequence = { 4, 12, 5 };
    private int[] case2Sequence = { 99, 11, 10 };

    // Obstacle cards
    private int[] case1Obstacles = { 3, 13 };
    private int[] case2Obstacles = { 7, 8, 9 };

    private int[] correctSequence;
    private int[] currentObstacles;

    private int currentStep = 0;
    private int obstacleCount = 0;
    private int currentCase;

    // Connect these in the Inspector
    public GameObject Case1;
    public GameObject Case2;
    public void SelectRandomCase()
    {
        currentCase = Random.Range(1, 3);

        if (currentCase == 1)
        {
            correctSequence = case1Sequence;
            currentObstacles = case1Obstacles;
        }
        else
        {
            correctSequence = case2Sequence;
            currentObstacles = case2Obstacles;
        }

        currentStep = 0;
        obstacleCount = 0;

        Case1.SetActive(currentCase == 1);
        Case2.SetActive(currentCase == 2);

        Debug.Log("Selected Case: " + currentCase);
    }

    public void PlayTreatment(int cardNumber)
    {
        // Check obstacle cards for the selected case
        foreach (int obstacle in currentObstacles)
        {
            if (cardNumber == obstacle)
            {
                obstacleCount++;

                Debug.Log("Obstacle card! Count: " + obstacleCount);

                if (obstacleCount > 3)
                {
                    Debug.Log("YOU LOSE!");
                }

                return;
            }
        }

        // Check previously completed treatments
        for (int i = 0; i < currentStep; i++)
        {
            if (correctSequence[i] == cardNumber)
            {
                Debug.Log("You have already completed this step!");
                return;
            }
        }

        // Check treatment order
        if (cardNumber == correctSequence[currentStep])
        {
            currentStep++;

            Debug.Log(currentStep + "/" +
                correctSequence.Length + " treatments completed!");

            if (currentStep == correctSequence.Length)
            {
                Debug.Log("YOU WIN!");
            }
        }
        else
        {
            bool belongsToCase = false;

            foreach (int treatment in correctSequence)
            {
                if (cardNumber == treatment)
                {
                    belongsToCase = true;
                    break;
                }
            }

            if (belongsToCase)
            {
                Debug.Log("Wrong treatment order!");
            }
            else
            {
                Debug.Log("This treatment is not for this case!");
            }
        }
    }
}
