using UnityEngine;
using TMPro;
/*Este script:
    solo controla texto en pantalla
    no es lógica del juego
    no es sistema global 
 */
public class ResultsUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.GetScore();
    }
}
