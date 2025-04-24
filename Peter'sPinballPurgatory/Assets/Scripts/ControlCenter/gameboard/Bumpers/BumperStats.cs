using UnityEngine;
using TMPro;

public class BumperStats : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateScore(effect.None);
    }

    public void updateScore(effect effect)
    {
        if (effect == effect.Halve)
        {
            scoreValue = Mathf.FloorToInt(scoreValue / 2);
        }
        else if (effect == effect.Double)
        {
            scoreValue = scoreValue * 2;
        }

        scoreText.text = scoreValue.ToString();
    }

    public int getScore()
    {
        return scoreValue;
    }

    public void setScore(int score)
    {
        scoreValue = score;
        updateScore(effect.None);
    }
}