using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 1.5f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }
}
