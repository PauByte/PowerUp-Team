using UnityEngine;

public class IcebergMover : MonoBehaviour
{
    public float speed = 4f;

    public float destroyY = -7f;

    void Update()
    {
        // mover hacia abajo
        transform.Translate(
            Vector3.down *
            speed *
            Time.deltaTime);

        // destruir al salir pantalla
        if (transform.position.y <
            destroyY)
        {
            Destroy(gameObject);
        }
    }
}