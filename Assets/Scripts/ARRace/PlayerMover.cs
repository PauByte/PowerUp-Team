using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float limit = 0.5f;

    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        float screenMiddle = Screen.width / 2;

        Vector3 moveDir = Vector3.zero;

        if (touch.position.x < screenMiddle)
        {
            moveDir = -arCamera.transform.right; // izquierda respecto a cámara
        }
        else
        {
            moveDir = arCamera.transform.right; // derecha respecto a cámara
        }

        Vector3 newPos = transform.position + moveDir * moveSpeed * Time.deltaTime;

        // 🔒 límite lateral para no salirte
        newPos.x = Mathf.Clamp(newPos.x, -limit, limit);

        transform.position = newPos;
    }
}