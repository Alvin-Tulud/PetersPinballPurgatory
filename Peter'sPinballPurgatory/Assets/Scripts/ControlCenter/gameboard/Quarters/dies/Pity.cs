using System.Numerics;
using UnityEngine;

public class Pity : QuarterAbstract
{
    private RoundStatTracker stats;
    private int deathCount;
    private AudioSource sfx;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();
        deathCount = 0;

        sfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (deathCount < stats.getDeathCount() && !stats.isRoundOver())
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
        // Play sound effect if available
        if (sfx != null)
        {
            sfx.Play();
        }

        Debug.Log("Check effect pity");

        GetComponent<CheckActive>().setActive();

        ScoreTracker score = FindAnyObjectByType<ScoreTracker>();

        score.AddScore(BigInteger.Divide(score.getScore(), 2));
    }
}
