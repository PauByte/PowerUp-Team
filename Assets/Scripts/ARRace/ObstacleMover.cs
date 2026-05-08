using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 1f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position +=
            -player.forward *
            speed *
            Time.deltaTime;
    }
}