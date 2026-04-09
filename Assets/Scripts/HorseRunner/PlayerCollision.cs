using UnityEngine;
/*
    evita múltiples game overs
    busca el sistema de score de esta escena
    guarda puntos
    carga el siguiente minijuego
 */

public class PlayerCollision : MonoBehaviour
{
    private bool isDead = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !isDead)
        {
            isDead = true;

            Debug.Log("GAME OVER");

            HorseRunnerScore score = FindFirstObjectByType<HorseRunnerScore>();
            if (score != null)
            {
                score.GameOver();
            }
        }
    }
}