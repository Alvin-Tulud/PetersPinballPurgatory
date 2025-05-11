using System.Numerics;
using UnityEngine;

public class Pity : QuarterAbstract
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
        if (stats.isDead() && deathCount < stats.getDeathCount() && !stats.isRoundOver())
        {
            Debug.Log("Check trigger pity");

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
        Debug.Log("Check effect pity");

        GetComponent<CheckActive>().setActive();

        ScoreTracker score = FindAnyObjectByType<ScoreTracker>();

        score.AddScore(BigInteger.Divide(score.getScore(), 2));
    }
}
