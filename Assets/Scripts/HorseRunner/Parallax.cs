using UnityEngine;
/*
    Cada frame mueve el objeto hacia la izquierda.
    Cuanto mayor sea speed, más rápido se mueve.
 */
public class Parallax : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
