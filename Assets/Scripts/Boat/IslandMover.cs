using UnityEngine;

public class IslandMover : MonoBehaviour
{
    public float speed = 0.5f;

    public float destroyY = -7f;

    void Update()
    {
        transform.Translate(
            Vector3.down *
            speed *
            Time.deltaTime);

        if (transform.position.y <
            destroyY)
        {
            Destroy(gameObject);
        }
    }
}