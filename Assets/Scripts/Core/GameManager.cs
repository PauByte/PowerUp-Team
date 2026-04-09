
using UnityEngine;
/*
Cerebro del juego entero:

    controla estado global
    vive entre escenas
    coordina todo

Es el núcleo y por eso va en Core
 
 */
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalScore = 0;
    public int currentGameIndex = 0;

    private void Awake()
    {
        // Singleton (solo uno en todo el juego)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
