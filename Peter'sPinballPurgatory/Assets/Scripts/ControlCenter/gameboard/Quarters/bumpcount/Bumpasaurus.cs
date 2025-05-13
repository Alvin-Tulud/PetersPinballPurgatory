using UnityEngine;

public class Bumpasaurus : QuarterAbstract
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
        if (stats.getHasLaunched() && bumps < stats.getBumps())
        {
            bumps++;

            if (bumps % 10 == 0 && bumps > 1)
            {
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
        Debug.Log("do effect gum gum: " + bumps);

        GetComponent<CheckActive>().setActive();

        BumperStats[] bstats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

        for (int i = 0; i < bstats.Length; i++)
        {
            if (bstats[i].scoreValue < 30)
            {
                bstats[i].updateScore(effect.Double);
            }
        }
    }
}
