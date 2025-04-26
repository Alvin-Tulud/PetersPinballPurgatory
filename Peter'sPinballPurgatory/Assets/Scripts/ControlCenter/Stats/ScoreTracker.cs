using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private static int score;
    private static int scoreMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetScore();
    }

    public void resetScore()
    {
        score = 0;
        setText();
    }

    public void AddScore(int add)
    {
        score += add;
        setText();
    }

    public void SetMaxScore(int max)
    {
        scoreMax = max;
    }

    public bool checkPass()
    {
        return score >= scoreMax;
    }

    public void setText()
    {
        scoreText.text = "Score:\n" + score + "/" + scoreMax;
    }
}
