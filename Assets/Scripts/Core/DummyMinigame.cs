using UnityEngine;
/*
script reutilizable
base para minijuegos

Cuando llames a FinishGame():
    suma puntos
    cambia de escena
 */
public class DummyMinigame : MonoBehaviour
{
    public int pointsToAdd = 10;

    public void FinishGame()
    {
        // Sumar puntos
        ScoreManager.Instance.AddScore(pointsToAdd);

        // Ir al siguiente juego
        SceneFlowManager.Instance.LoadNextScene();
    }
}
