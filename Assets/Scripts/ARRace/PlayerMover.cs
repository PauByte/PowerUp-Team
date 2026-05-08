using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float leftLimit = -0.6f;
    public float rightLimit = 0.6f;

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        float move = 0f;

        if (touch.position.x < Screen.width / 2)
        {
            move = -1f;
        }
        else
        {
            move = 1f;
        }

        Vector3 pos = transform.localPosition;

        pos.x += move * moveSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);

        transform.localPosition = pos;
    }
}