using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    public float speed = 6f;
    public float resetX = -20f;
    public float startX = 20f;

    public float pixelsPerUnit = 32f; //32

    void Update()
    {
        // mover
        float move = speed * Time.deltaTime;
        transform.position += new Vector3(-move, 0, 0);

        // snap a pixel
        float snappedX = Mathf.Round(transform.position.x * pixelsPerUnit) / pixelsPerUnit;

        transform.position = new Vector3(
            snappedX,
            transform.position.y,
            transform.position.z
        );

        // loop
        if (transform.position.x <= resetX)
        {
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        }
    }
}