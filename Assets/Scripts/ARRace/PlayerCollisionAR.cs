using UnityEngine;

public class PlayerCollisionAR : MonoBehaviour
{
    private bool gameOver = false;

    private ARRaceGameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<ARRaceGameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameOver) return;

        if (other.CompareTag("Obstacle"))
        {
            gameOver = true;

            gameManager.GameOver();
        }
    }
}