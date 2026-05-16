using UnityEngine;

public class VRSpawner : MonoBehaviour
{
    public GameObject targetPrefab;

    public float spawnDistance = 8f;

    private GameObject currentTarget;

    void Start()
    {
        SpawnTarget();
    }

    void Update()
    {
        if (currentTarget == null)
        {
            SpawnTarget();
        }
    }

    void SpawnTarget()
    {
        float randomX = Random.Range(-4f, 4f);
        float randomY = Random.Range(0f, 3f);

        Vector3 spawnPos =
            new Vector3(randomX, randomY, spawnDistance);

        currentTarget =
            Instantiate(targetPrefab, spawnPos, Quaternion.identity);
    }
}
