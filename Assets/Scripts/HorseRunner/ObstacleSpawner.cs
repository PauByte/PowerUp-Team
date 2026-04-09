using UnityEngine;

//Crea obstaculos random
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float minSpawnTime = 1.5f;
    public float maxSpawnTime = 3f;

    void Start()
    {
        SpawnAgain();
    }

    void SpawnAgain()
    {
        float delay = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke(nameof(SpawnObstacle), delay);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        SpawnAgain();
    }
}