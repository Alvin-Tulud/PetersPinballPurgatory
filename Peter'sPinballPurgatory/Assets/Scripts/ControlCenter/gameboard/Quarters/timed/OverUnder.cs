using System.Collections;
using UnityEngine;
using static QuarterAbstract;

public class OverUnder : QuarterAbstract
{
    private RoundStatTracker stats;
    private int checkedTime;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();
        checkedTime = 0;
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        int timecheck = Mathf.FloorToInt(stats.getTime());

        //Debug.Log(timecheck);
        if (timecheck != checkedTime && timecheck % 1 == 0 && stats.getTime() > 0.5f && FindAnyObjectByType<flipwalloff>().getwallPassed())
        {
            Debug.Log("Check trigger overunder");

            checkedTime = timecheck;

            doEffect();
        }

        if (!FindAnyObjectByType<flipwalloff>().getwallPassed())
        {
            checkedTime = 0;
        }
    }

    public override void doEffect()
    {
        Debug.Log("Check effect overunder");

        GetComponent<CheckActive>().setActive();

        if (GameObject.FindWithTag("Player") || GameObject.FindWithTag("FakePlayer"))
        {
            BumperStats[] bstats = FindObjectsByType<BumperStats>(FindObjectsSortMode.None);

            int randBumper = Random.Range(0, bstats.Length);

            bstats[randBumper].updateScore(effect.Double);

            randBumper = Random.Range(0, bstats.Length);

            bstats[randBumper].updateScore(effect.Halve);
        }
        
    }
}
