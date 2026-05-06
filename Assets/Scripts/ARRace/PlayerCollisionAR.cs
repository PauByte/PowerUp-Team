using UnityEngine;

public class PlayerCollisionAR : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER");

            // Llamar a tu sistema de escenas
            SceneFlowManager.Instance.LoadNextScene();
        }
    }
}