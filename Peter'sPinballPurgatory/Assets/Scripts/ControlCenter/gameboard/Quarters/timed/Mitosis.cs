using System.Collections;
using UnityEngine;

public class Mitosis : QuarterAbstract
{
    private RoundStatTracker stats;

    public GameObject fakePeter;

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
        if (stats.getHasLaunched() && !stats.isDead() && stats.getTime() % 3 == 0 && stats.getTime() > 2f && FindAnyObjectByType<flipwalloff>().getwallPassed())
        {
            Debug.Log("Check trigger Mitosis");

            doEffect();
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
