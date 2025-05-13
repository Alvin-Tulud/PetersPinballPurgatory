using System.Collections;
using UnityEngine;

public class Mitosis : QuarterAbstract
{
    private RoundStatTracker stats;
    private int checkedTime;

    public GameObject fakePeter;

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
        if (timecheck != checkedTime && timecheck % 3 == 0 && stats.getTime() > 2f && FindAnyObjectByType<flipwalloff>().getwallPassed())
        {
            Debug.Log("Check trigger Mitosis");

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
        Debug.Log("Check effect Mitosis");

        GetComponent<CheckActive>().setActive();

        if (GameObject.FindWithTag("Player"))
        {
            Debug.Log("found");

            GameObject player = GameObject.FindWithTag("Player");

            Debug.Log(fakePeter != null);

            Instantiate(fakePeter, player.transform.position, player.transform.rotation);
        }
    }
}
