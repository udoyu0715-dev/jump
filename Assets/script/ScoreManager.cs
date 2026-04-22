using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private float score = 0f;
    private bool isGameOver = false;

    void Start()
    {
        //int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
       // highScoreText.text = "High Score: " + savedHighScore;
    }

    void Update()
    {
        if (isGameOver) return;

        score += Time.deltaTime * 10f;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    public void GameOver()
    {
        isGameOver = true;

        int finalScore = Mathf.FloorToInt(score);
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (finalScore > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", finalScore);
            PlayerPrefs.Save();
        }
    }
}