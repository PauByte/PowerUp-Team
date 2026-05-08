using UnityEngine;

public class RoadLineMover : MonoBehaviour
{
    public float speed = 2f;
    public float resetDistance = -2f;
    public float startDistance = 4f;

    private Vector3 startPosition;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        startPosition = transform.localPosition;
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.localPosition.z < resetDistance)
        {
            Vector3 pos = transform.localPosition;

            pos.z = startDistance;

            transform.localPosition = pos;
        }
    }
}