using System.Collections;
using UnityEngine;
using static QuarterAbstract;

public class OverUnder : QuarterAbstract
{
    private RoundStatTracker stats;

    private bool doOnce;
    private bool canCheck;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();

        doOnce = true;

        canCheck = true;
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        if (doOnce && stats.getHasLaunched() && canCheck)
        {
            StartCoroutine(every1second());
        }

        if (stats.isDead())
        {
            doOnce = false;
        }
    }

    IEnumerator every1second()
    {
        canCheck = false;

        Debug.Log("Check trigger overunder");

        doEffect();

        yield return new WaitForSeconds(1f);

        canCheck = true;
    }

    public override void doEffect()
    {
        Debug.Log("Check effect overunder");

        BumperStats[] bstats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

        int randBumper = Random.Range(0, bstats.Length);

        bstats[randBumper].updateScore(effect.Double);

        randBumper = Random.Range(0, bstats.Length);

        bstats[randBumper].updateScore(effect.Halve);
    }
}
