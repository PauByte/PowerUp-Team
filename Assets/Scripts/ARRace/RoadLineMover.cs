using UnityEngine;

public class RoadLineMover : MonoBehaviour
{
    public float speed = 2f;

    public float resetDistance = -0.438f;
    public float startDistance = 0.438f;

    void Update()
    {
        transform.Translate(
            Vector3.back *
            speed *
            Time.deltaTime);

        if (transform.localPosition.z <
            resetDistance)
        {
            Vector3 pos =
                transform.localPosition;

            // mantener separación
            pos.z +=
                (startDistance - resetDistance);

            transform.localPosition = pos;
        }
    }
}