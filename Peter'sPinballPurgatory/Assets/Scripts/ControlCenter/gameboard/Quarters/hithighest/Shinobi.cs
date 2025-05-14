using System.Numerics;
using UnityEngine;

public class Shinobi : QuarterAbstract
{
    private RoundStatTracker stats;
    private ScoreTracker score;
    private bool doOnce;
    private int bumps;
    private AudioSource sfx;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();
        score = FindAnyObjectByType<ScoreTracker>();
        doOnce = true;
        bumps = 0;

        sfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (stats.getBumps() > bumps && 
            stats.getBumps() < 2 &&
            !stats.isDead() && 
            stats.getfirsthighesthit())
        {
            bumps++;

            if (bumps % 1 == 0 && bumps > 0)
            {
                Debug.Log("Check trigger shinobi");

                doEffect();
            }
        }

        if (stats.isRoundOver() || stats.getBumps() == 0)
        {
            bumps = 0;
        }
    }
    public override void doEffect()
    {
        Debug.Log("do effect shinobi");

        // Play SFX if available
        if (sfx != null)
        {
            sfx.Play();
        }

        GetComponent<CheckActive>().setActive();

        BumperStats[] bstats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

        for (int i = 0; i < bstats.Length; i++)
        {
            bstats[i].updateScore(effect.Double);
        }
    }
}
