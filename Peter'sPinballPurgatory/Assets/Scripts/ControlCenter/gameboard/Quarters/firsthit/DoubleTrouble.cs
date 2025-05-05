using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class DoubleTrouble : QuarterAbstract
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
            Debug.Log("Check trigger doubletrouble");

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
        Debug.Log("Check effect doubletrouble");

        BumperStats[] bstats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

        for (int i = 0; i < stats.getRound(); i++)
        {
            int randBumper = Random.Range(0, bstats.Length);

            bstats[randBumper].updateScore(effect.Double);

            Debug.Log(bstats[randBumper].name + ": " + bstats[randBumper].getScore());
        }
    }
}
