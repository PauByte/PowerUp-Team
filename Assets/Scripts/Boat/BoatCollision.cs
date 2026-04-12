using UnityEngine;

public class BoatCollision : MonoBehaviour
{
    public BoatScoreController scoreController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Iceberg"))
        {
            scoreController.GameOver();
        }
    }
}