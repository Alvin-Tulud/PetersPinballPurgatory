using System.Numerics;
using UnityEngine;

public class Martyr : QuarterAbstract
{
    private RoundStatTracker stats;
    private int deathCount;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();
        deathCount = 0;
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (deathCount < stats.getDeathCount() && !stats.isRoundOver())
        {
            Debug.Log("Check trigger martyr");

            deathCount++;

            doEffect();
        }

        if (!FindAnyObjectByType<flipwalloff>().getwallPassed())
        {
            deathCount = 0;
        }
    }

    public override void doEffect()
    {
        Debug.Log("Check effect martyr");

        GetComponent<CheckActive>().setActive();

        ScoreTracker score = FindAnyObjectByType<ScoreTracker>();

        if (stats.getRound() < 15)
        {
            score.AddScore(20);
        }
        else
        {
            score.AddScore(200);
        }
    }
}
