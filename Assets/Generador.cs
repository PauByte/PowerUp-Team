using UnityEngine;

public class Generador : MonoBehaviour
{
    // Poner el prefab que he creado  del asteroide aqui
    public GameObject asteroidPrefab;

    // Tiempo entre cada aparición
    public float RatioGeneracion = 2.0f;

    // Distancia a la que apareceran los asteroides 
    public float DistanciaGeneracion = 30.0f;

    // Importante hacer que spawneen en diferentes puntos para que no vengan todos en linea recta
    public float RangoGeneracion = 10.0f;

    void Start()
    {
        // Llamada a la funcion para que spawneen seguido
        // Empieza con delay de 1 segundo y cada segundo spawnea (Toqueteable si es mucho rate)
        InvokeRepeating("Spawn", 1.0f, RatioGeneracion);
    }

    void Spawn()
    {
        // Calculadora de punto random
        float randomX = Random.Range(-RangoGeneracion, RangoGeneracion);
        float randomY = Random.Range(-RangoGeneracion, RangoGeneracion);

        Vector3 spawnPos = new Vector3(randomX, randomY, DistanciaGeneracion);

        // Se crea un asteroide en la posicion
        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}