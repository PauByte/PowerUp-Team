using TMPro;
using UnityEngine;

public class HorseRunnerUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private HorseRunnerScore scoreManager;

    void Start()
    {
        scoreManager = FindFirstObjectByType<HorseRunnerScore>();
    }

    void Update()
    {
        if (scoreManager != null)
        {
            scoreText.text = "Score: " + Mathf.RoundToInt(scoreManager.score);
        }
    }
}
