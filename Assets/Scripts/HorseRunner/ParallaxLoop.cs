using UnityEngine;

public class ParallaxLoop : MonoBehaviour
{
    public float speed = 1f;
    public float resetPositionX = -10f;
    public float startPositionX = 10f;

    public float pixelsPerUnit = 64f; //64

    void Update()
    {
        // mover
        float move = speed * Time.deltaTime;
        transform.position += new Vector3(-move, 0, 0);

        // snap a pixel (elimina líneas)
        float snappedX = Mathf.Round(transform.position.x * pixelsPerUnit) / pixelsPerUnit;

        transform.position = new Vector3(
            snappedX,
            transform.position.y,
            transform.position.z
        );

        // loop
        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }
}