using UnityEngine;

public class IcebergSpawner : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private GameObject icebergPrefab;

    [SerializeField]
    private Transform player;

    [Header("Spawn")]
    [SerializeField]
    private float spawnY = 7f;

    [SerializeField]
    private float spawnRate = 2f;

    private float timer;

    [Header("Lanes")]
    [SerializeField]
    private float lane1 = -3f;

    [SerializeField]
    private float lane2 = -1f;

    [SerializeField]
    private float lane3 = 1f;

    [SerializeField]
    private float lane4 = 3f;

    private float[] lanes;

    void Start()
    {
        // buscar player automáticamente
        GameObject foundPlayer =
            GameObject.FindWithTag("Player");

        if (foundPlayer != null)
        {
            player =
                foundPlayer.transform;
        }

        lanes = new float[]
        {
        lane1,
        lane2,
        lane3,
        lane4
        };
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnIceberg();
            timer = 0f;
        }
    }

    void SpawnIceberg()
    {
        if (player == null) return;

        // encontrar carril más cercano al player
        float closestLane =
            lanes[0];

        float closestDistance =
            Mathf.Abs(
                player.position.x -
                lanes[0]);

        foreach (float lane in lanes)
        {
            float distance =
                Mathf.Abs(
                    player.position.x -
                    lane);

            if (distance <
                closestDistance)
            {
                closestDistance =
                    distance;

                closestLane =
                    lane;
            }
        }

        Vector3 spawnPos =
            new Vector3(
                closestLane,
                spawnY,
                0f);

        Instantiate(
            icebergPrefab,
            spawnPos,
            Quaternion.identity);
    }
}