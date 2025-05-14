using System.Collections;
using UnityEngine;

public class GumGum : QuarterAbstract
{
    private RoundStatTracker stats;
    private int bumps;
    private AudioSource sfx;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();
        sfx = GetComponent<AudioSource>();
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

        if (stats.isRoundOver() || stats.getBumps() == 0)
        {
            bumps = 0;
        }
    }

    public override void doEffect()
    {
        // Play the item SFX if available
        if (sfx != null)
        {
            sfx.Play();
        }

        Debug.Log("do effect gum gum: " + bumps);

        GetComponent<CheckActive>().setActive();

        ScoreTracker score = FindAnyObjectByType<ScoreTracker>();
        score.AddScore(bumps);
    }
}
