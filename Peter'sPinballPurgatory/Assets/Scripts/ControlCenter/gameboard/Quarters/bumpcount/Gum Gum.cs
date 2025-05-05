using System.Collections;
using UnityEngine;

public class GumGum : QuarterAbstract
{
    private RoundStatTracker stats;

    private int bumps;

    private bool doOnce;
    private bool canCheck;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();

        doOnce = true;

        canCheck = true;

        bumps = 0;
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (stats.getHasLaunched() && bumps < stats.getBumps())
        {
            bumps++;

            doEffect();
        }

        if (!stats.getHasLaunched())
        {
            bumps = 0;
        }
    }

    public override void doEffect()
    {
        Debug.Log("Check effect overunder");
        
        ScoreTracker score = FindAnyObjectByType<ScoreTracker>();

        score.AddScore(bumps);
    }
}
