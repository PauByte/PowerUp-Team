using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        float screenMiddle = Screen.width / 2;

        if (touch.position.x < screenMiddle)
        {
            // izquierda
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            // derecha
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}