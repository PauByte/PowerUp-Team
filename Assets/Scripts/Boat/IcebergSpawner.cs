using UnityEngine;

public class IcebergSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject icebergPrefab;

    [SerializeField]
    private GameObject frozenIslandPrefab;

    private Transform player;

    [Header("Spawn")]
    [SerializeField]
    private float spawnY = 7f;

    [SerializeField]
    private float spawnRate = 0.5f;

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

    private float gameTimer;

    private bool islandEventActive = false;

    private float islandCooldown = 10f;
    private float nextIslandCheck = 5f;

    void Start()
    {
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
        gameTimer += Time.deltaTime;
        timer += Time.deltaTime;

        // revisar si toca evento isla
        if (gameTimer >= nextIslandCheck)
        {
            nextIslandCheck += islandCooldown;

            // 40% probabilidad
            if (Random.value < 1f)
            {
                SpawnFrozenIsland();
            }
        }

        // spawner normal
        if (!islandEventActive &&
            timer >= spawnRate)
        {
            SpawnIceberg();

            timer = 0f;
        }
    }

    void SpawnIceberg()
    {
        if (player == null) return;

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

    void SpawnFrozenIsland()
    {
        islandEventActive = true;

        // ocupa dos carriles
        int laneIndex =
            Random.Range(
                0,
                lanes.Length - 1);

        float centerX =
            (
                lanes[laneIndex] +
                lanes[laneIndex + 1]
            ) / 2f;

        Vector3 spawnPos =
            new Vector3(
                centerX,
                spawnY,
                0f);

        Instantiate(
            frozenIslandPrefab,
            spawnPos,
            Quaternion.identity);

        Invoke(
            nameof(EndIslandEvent),
            1f);
    }

    void EndIslandEvent()
    {
        islandEventActive = false;
    }
}