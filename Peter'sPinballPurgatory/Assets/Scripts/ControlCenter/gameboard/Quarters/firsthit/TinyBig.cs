using System.Numerics;
using UnityEngine;

public class TinyBig : QuarterAbstract
{
    private RoundStatTracker stats;

    private bool doOnce;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();

        doOnce = true;
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (doOnce && stats.getBumps() == 1)
        {
            Debug.Log("Check trigger TinyBig");

            doEffect();

            doOnce = false;
        }

        if (stats.getBumps() == 0)
        {
            doOnce = true;
        }
    }

    public override void doEffect()
    {
        Debug.Log("Check effect TinyBig");

        BumperStats[] bstats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

        ScoreTracker score = FindAnyObjectByType<ScoreTracker>();

        BigInteger lowest = score.getMaxScore();

        for (int i = 0; i < bstats.Length; i++)
        {
            if (bstats[i].getScore() < lowest)
            {
                lowest = bstats[i].getScore();
            }
        }

        score.AddScore(5 * lowest);
    }
}
