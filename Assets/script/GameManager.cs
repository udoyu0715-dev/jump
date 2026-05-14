using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public ScoreManager scoreManager;
    public Player player;

    void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        if (scoreManager != null)
        {
            scoreManager.GameOver();
        }

        if (player != null)
        {
            player.StopAnimation();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        if (player != null)
        {
            player.ResetAnimation();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}