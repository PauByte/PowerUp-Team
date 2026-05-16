using TMPro;
using UnityEngine;

public class VRGameScore : MonoBehaviour
{
    public float score = 0f;
    public float scoreSpeed = 1f;

    private bool isGameOver = false;

    [Header("UI")]
    public TextMeshProUGUI resultText;

    void Start()
    {
        Time.timeScale = 1f;

        if (resultText != null)
        {
            resultText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime * scoreSpeed;

            if (score >= 100f)
            {
                Win();
            }
        }
    }

    void Win()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        Debug.Log("VR WIN");

        int finalScore = 100;

        ScoreManager.Instance.AddScore(finalScore);

        ShowWin();

        Time.timeScale = 0.2f;

        Invoke(nameof(LoadNext), 1f);
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        int finalScore = Mathf.RoundToInt(score);
        finalScore = Mathf.Clamp(finalScore, 0, 100);

        Debug.Log("VR GAME OVER - Score: " + finalScore);

        ScoreManager.Instance.AddScore(finalScore);

        ShowGameOver();

        Time.timeScale = 0.5f;

        Invoke(nameof(LoadNext), 1f);
    }

    void LoadNext()
    {
        SceneFlowManager.Instance.LoadNextScene();
    }

    void ShowGameOver()
    {
        if (resultText != null)
        {
            resultText.gameObject.SetActive(true);
            resultText.text = "GAME OVER";
        }
    }

    void ShowWin()
    {
        if (resultText != null)
        {
            resultText.gameObject.SetActive(true);
            resultText.text = "YOU WIN";
        }
    }
}