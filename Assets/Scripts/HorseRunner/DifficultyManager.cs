using UnityEngine;
/*
    Crea la dificultad progresiva 
    cada segundo aumenta un poco la velocidad global de los obstáculos
    hace que el juego se vuelva más difícil poco a poco
 */
public class DifficultyManager : MonoBehaviour
{
    public float speedIncreasePerSecond = 0.2f;//0.2
    public float maxSpeed = 14f;

    void Update()
    {
        if (ObstacleMove.globalSpeed < maxSpeed)
        {
            ObstacleMove.globalSpeed += speedIncreasePerSecond * Time.deltaTime;
        }
    }
}
