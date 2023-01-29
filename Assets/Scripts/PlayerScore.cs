using UnityEngine.UI;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    int score;
    int bestScore;
    [SerializeField] Text scoreText;
    [SerializeField] Text BestScoreText;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        BestScoreText.text = bestScore.ToString();
    }

    public void AddScore(Asteroid asteroid)
    {
        score += 20;
        scoreText.text = score.ToString();
        if (bestScore < score)
            PlayerPrefs.SetInt("bestScore", score);
    }
}
