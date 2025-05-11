using System.Collections;
using UnityEngine;
using static QuarterAbstract;

public class OverUnder : QuarterAbstract
{
    private RoundStatTracker stats;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (stats.getHasLaunched() && !stats.isDead() && stats.getTime() % 1 == 0 && stats.getTime() > 0.1f && FindAnyObjectByType<flipwalloff>().getwallPassed())
        {
            Debug.Log("Check trigger overunder");

            doEffect();
        }
    }

    public override void doEffect()
    {
        Debug.Log("Check effect overunder");

        GetComponent<CheckActive>().setActive();

        BumperStats[] bstats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

        int randBumper = Random.Range(0, bstats.Length);

        bstats[randBumper].updateScore(effect.Double);

        randBumper = Random.Range(0, bstats.Length);

        bstats[randBumper].updateScore(effect.Halve);
    }
}
