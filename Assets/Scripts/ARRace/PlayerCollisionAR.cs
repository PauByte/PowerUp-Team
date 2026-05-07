using UnityEngine;
using System.Collections;

public class PlayerCollisionAR : MonoBehaviour
{
    private bool gameOver = false;

    private GameObject gameOverText;

    void Start()
    {
        gameOverText = GameObject.Find("GameOverText");

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameOver) return;

        if (other.CompareTag("Obstacle"))
        {
            gameOver = true;

            StartCoroutine(GameOverSequence());
        }
    }

    IEnumerator GameOverSequence()
    {
        // Mostrar GAME OVER
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        // Cámara lenta
        Time.timeScale = 0.3f;

        // Esperar
        yield return new WaitForSecondsRealtime(2f);

        // Restaurar tiempo
        Time.timeScale = 1f;

        // Siguiente escena
        SceneFlowManager.Instance.LoadNextScene();
    }
}