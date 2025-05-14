using System.Collections;
using UnityEngine;

public class Mitosis : QuarterAbstract
{
    private RoundStatTracker stats;
    private int checkedTime;

    public GameObject fakePeter;

    private AudioSource sfx;

    private void Awake()
    {
        stats = FindAnyObjectByType<RoundStatTracker>();
        checkedTime = 0;
        sfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        checkTrigger();
    }

    public override void checkTrigger()
    {
        int timecheck = Mathf.FloorToInt(stats.getTime());

        if (timecheck != checkedTime &&
            timecheck % 3 == 0 &&
            stats.getTime() > 2f &&
            FindAnyObjectByType<flipwalloff>().getwallPassed() &&
            GameObject.FindWithTag("Player"))
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

        // ✅ Only play sound when item is actually active
        if (GetComponent<CheckActive>().getActive() && sfx != null)
        {
            sfx.Play();
        }

        GameObject player = GameObject.FindWithTag("Player");

        Instantiate(fakePeter, player.transform.position, player.transform.rotation);
    }
}
