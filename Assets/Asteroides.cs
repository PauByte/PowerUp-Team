using UnityEngine;

public class Asteroides : MonoBehaviour
{
    //Importante dejar la speed en publico y sin valor en caso de querer hacer que los asteroides aceleren con el tiempo
    public float speed = 5f;

    void Update()
    {
        // Movimiento hacia la cam aqui
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Deleter de asteroides cuando han pasado al jugador sino se rompe el juego
        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }

    // Funcion que se activa al hacer el hover con la mirilla
    public void DestruyealMirar()
    {
        // Accion de destruir
        Destroy(gameObject);
    }
}