using System.Collections;
using UnityEngine;

public class GumGum : QuarterAbstract
{
    private RoundStatTracker stats;

    private int bumps;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();

        bumps = 0;
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (stats.getHasLaunched() && bumps < stats.getBumps() && !stats.isDead())
        {
            bumps++;

            doEffect();
        }

        if (stats.isRoundOver())
        {
            bumps = 0;
        }
    }

    public override void doEffect()
    {
        GetComponent<AudioSource>().Play();

        Debug.Log("do effect gum gum: " + bumps);

        GetComponent<CheckActive>().setActive();
        
        ScoreTracker score = FindAnyObjectByType<ScoreTracker>();

        score.AddScore(bumps);
    }
}
