using UnityEngine;
using TMPro;
using System.Numerics;

public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private static BigInteger score;
    private static BigInteger scoreMax;
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

    public void AddScore(BigInteger add)
    {
        score += add;
        setText();
    }

    public void SetMaxScore(BigInteger max)
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

    public BigInteger getScore()
    {
        return score;
    }
}
