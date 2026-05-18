using UnityEngine;

public class VRSpawner : MonoBehaviour
{
    public GameObject targetPrefab;

    public float spawnDistance = 12f;
    public float spawnInterval = 2f;

    // cámara VR
    public Transform playerCamera;

    private float timer;

    void Start()
    {
        SpawnTarget();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnTarget();
            timer = 0f;
        }
    }

    void SpawnTarget()
    {
        if (playerCamera == null)
            return;

        // punto delante de donde mira
        Vector3 spawnPosition =
            playerCamera.position +
            playerCamera.forward * spawnDistance;

        // pequeña variación para que no salgan EXACTAMENTE en el centro
        spawnPosition +=
            playerCamera.right *
            Random.Range(-1.5f, 1.5f);

        spawnPosition +=
            playerCamera.up *
            Random.Range(-1f, 1f);

        Instantiate(
            targetPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}