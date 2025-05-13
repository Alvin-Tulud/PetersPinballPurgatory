using UnityEngine;
using TMPro;
using System.Numerics;

public class BumperStats : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI effectText;
    public BigInteger scoreValue;

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
            effectText.text = "1/2";

            if (scoreValue == 0 || scoreValue == 1)
            {
                scoreValue = 1;
            }
            else
            {
                scoreValue = BigInteger.Divide(scoreValue, 2);
            }
        }
        else if (effect == effect.Double)
        {
            effectText.text = "x2";

            scoreValue = scoreValue * 2;
        }

        scoreText.text = intchain.FormatLargeNumber((double)scoreValue);

        GetComponent<Animator>().SetTrigger("Effect");
    }

    public BigInteger getScore()
    {
        return scoreValue;
    }

    public void setScore(BigInteger score)
    {
        scoreValue = score;
        updateScore(effect.None);
    }
}