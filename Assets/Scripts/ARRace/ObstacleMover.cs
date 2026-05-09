using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 1.5f;

    public float destroyDistance = 3f;

    private Transform player;

    void Start()
    {
        player =
            GameObject
            .FindWithTag("Player")
            .transform;
    }

    void Update()
    {
        transform.Translate(
            Vector3.back *
            speed *
            Time.deltaTime,
            Space.World);

        if (player != null)
        {
            float distance =
                Vector3.Distance(
                    transform.position,
                    player.position);

            if (distance >
                destroyDistance &&
                transform.position.z <
                player.position.z)
            {
                Destroy(gameObject);
            }
        }
    }
}