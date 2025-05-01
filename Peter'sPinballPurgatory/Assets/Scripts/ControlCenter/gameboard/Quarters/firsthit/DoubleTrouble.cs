using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class DoubleTrouble : QuarterAbstract
{
    public int count;
    public raritytype rarity;
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
            Debug.Log("Check trigger");

            doEffect();

            doOnce = false;
        }

        if (stats.isDead())
        {
            doOnce = true;
        }
    }

    public override void doEffect()
    {
        Debug.Log("Check effect");

        BumperStats[] bstats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

        for (int i = 0; i < stats.getRound(); i++)
        {
            int randBumper = Random.Range(0, bstats.Length);

            bstats[randBumper].updateScore(effect.Double);

            Debug.Log(bstats[randBumper].name + ": " + bstats[randBumper].getScore());
        }
    }

    public override int getRarity()
    {
        if (rarity == raritytype.common)
        {
            return 70;
        }
        else if (rarity == raritytype.uncommon)
        {
            return 20;
        }
        else
        {
            return 10;
        }
    }
}
