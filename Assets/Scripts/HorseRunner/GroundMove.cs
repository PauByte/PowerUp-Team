using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float speed = 6f;//6

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
