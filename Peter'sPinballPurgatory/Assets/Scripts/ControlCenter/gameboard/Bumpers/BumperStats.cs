using UnityEngine;
using TMPro;

public class BumperStats : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public long scoreValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateScore(effect.None);
    }

    private void Update()
    {
        if (scoreValue == 0 || scoreValue == 1)
        {
            scoreValue = 1;
        }
    }

    public void updateScore(effect effect)
    {
        if (effect == effect.Halve)
        {
            if (scoreValue == 0 || scoreValue == 1)
            {
                scoreValue = 1;
            }
            else
            {
                scoreValue = Mathf.FloorToInt(scoreValue / 2);
            }
        }
        else if (effect == effect.Double)
        {
            scoreValue = scoreValue * 2;
        }

        scoreText.text = scoreValue.ToString();
    }

    public long getScore()
    {
        return scoreValue;
    }

    public void setScore(int score)
    {
        scoreValue = score;
        updateScore(effect.None);
    }
}