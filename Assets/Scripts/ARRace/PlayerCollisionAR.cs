using UnityEngine;
using System.Collections;

public class PlayerCollisionAR : MonoBehaviour
{
    private bool gameOver = false;

    private ARRaceGameManager gameManager;
    private AudioSource hitSound;

    void Start()
    {
        gameManager =
            FindFirstObjectByType<ARRaceGameManager>();

        hitSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameOver) return;

        if (other.CompareTag("Obstacle"))
        {
            gameOver = true;

            StartCoroutine(CrashSequence());
        }
    }

    IEnumerator CrashSequence()
    {
        // sonido choque
        if (hitSound != null)
        {
            hitSound.Play();
        }

        // pequeña espera
        yield return new WaitForSeconds(0.3f);

        // game over
        gameManager.GameOver();
    }
}